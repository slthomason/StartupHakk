using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace OrderHubCli
{
    [HelpOption("--help")]
    abstract class OrderHubCmdBase
    {
        private UserProfile _userProfile;
        private OrderHubClient _orderHubClient;

        protected ILogger _logger;
        protected IHttpClientFactory _httpClientFactory;
        protected IConsole _console;

        [Option(CommandOptionType.SingleValue, ShortName = "", LongName = "profile", Description = "local profile name", ValueName = "profile name", ShowInHelpText = true)]
        public string Profile { get; set; } = "default";

        [Option(CommandOptionType.SingleValue, ShortName = "", LongName = "output-format", Description = "output format", ValueName = "output format", ShowInHelpText = true)]
        public string OutputFormat { get; set; } = "json";

        [Option(CommandOptionType.SingleValue, ShortName = "o", LongName = "output", Description = "output file", ValueName = "output file", ShowInHelpText = true)]
        public string OutputFile { get; set; }

        [Option(CommandOptionType.SingleValue, ShortName = "", LongName = "xslt", Description = "xslt input file for transformation", ValueName = "xslt file", ShowInHelpText = true)]
        public string XSLTFile { get; set; }

        protected string FileNameSuffix { get; set; }

        protected virtual Task<int> OnExecute(CommandLineApplication app)
        {
            return Task.FromResult(0);
        }

        protected string ProfileFolder
        {
            get
            {
                return $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile, Environment.SpecialFolderOption.Create)}\\.orderhub\\";
            }
        }


        protected UserProfile UserProfile
        {
            get
            {
                if (_userProfile == null)
                {
                    var text = File.ReadAllText($"{ProfileFolder}{Profile}");
                    if (!string.IsNullOrEmpty(text))
                    {
                        _userProfile = JsonConvert.DeserializeObject<UserProfile>(text);
                        if (_userProfile != null)
                        {
                            _userProfile.Password = Decrypt(_userProfile.Password);
                        }
                    }
                }
                return _userProfile;
            }
        }

        protected OrderHubClient OrderHubClient
        {
            get
            {
                if (_orderHubClient == null)
                {
                    _orderHubClient = new OrderHubClient(_httpClientFactory.CreateClient(), UserProfile, _logger);
                }

                return _orderHubClient;
            }
        }

        protected String SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        private string EncryptKey
        {
            get
            {
                var keyLen = 32;
                var key = Environment.UserName;
                if (key.Length > keyLen)
                {
                    key = key.Substring(0, keyLen);
                }
                else if (key.Length < keyLen)
                {
                    var len = key.Length;
                    for (var i = 0; i < keyLen - len; i++)
                    {
                        key += ((char)(65 + i)).ToString();
                    }
                }
                return key;
            }
        }

        protected string Encrypt(string text)
        {
            var keyString = EncryptKey;
            var key = Encoding.UTF8.GetBytes(keyString);
            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        var iv = aesAlg.IV;
                        var decryptedContent = msEncrypt.ToArray();
                        var result = new byte[iv.Length + decryptedContent.Length];
                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        protected string Decrypt(string cipherText)
        {
            var keyString = EncryptKey;
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[fullCipher.Length - 16];
            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            var key = Encoding.UTF8.GetBytes(keyString);
            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                    return result;
                }
            }
        }

        protected void OnException(Exception ex)
        {
            OutputError(ex.Message);
            _logger.LogError(ex.Message);
            _logger.LogDebug(ex, ex.Message);
        }

        protected void OutputJson(string data, string rootElementName, string arrayElementName)
        {
            switch (OutputFormat.ToLowerInvariant())
            {
                case "json":
                    Output(data);
                    break;
                case "xml":
                    var xml = JsonConvert.DeserializeXNode(data.StartsWith("[") ? $"{{{arrayElementName}:{data}}}" : data, rootElementName);
                    OutputXml(xml);
                    break;
                default:
                    OutputError("format not supported");
                    break;
            }
        }

        protected void OutputXml(XDocument data)
        {
            if (string.IsNullOrEmpty(XSLTFile))
            {
                Output(data.ToString());
            }
            else
            {
                XsltSettings settings = new XsltSettings(true, true);
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(XSLTFile, settings, null);
                XsltArgumentList argList = new XsltArgumentList();
                var ext = new XSLTExtension();
                argList.AddExtensionObject("urn:orderhub-cli", ext);
                var sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                {
                    xslt.Transform(data.CreateReader(ReaderOptions.None), argList, writer);
                    writer.Flush();
                }
                Output(sb.ToString());
            }
        }

        protected void Output(string data)
        {
            if (!string.IsNullOrEmpty(OutputFile))
            {
                OutputToFile(data);
            }
            else
            {
                OutputToConsole(data);
            }
        }

        protected void OutputToFile(string data)
        {
            File.WriteAllText(string.IsNullOrEmpty(FileNameSuffix) ? OutputFile : OutputFile.Replace("*", FileNameSuffix), data);
        }

        protected void OutputToConsole(string data)
        {
            _console.BackgroundColor = ConsoleColor.Black;
            _console.ForegroundColor = ConsoleColor.White;
            _console.Out.Write(data);
            _console.ResetColor();
        }

        protected void OutputError(string message)
        {
            _console.BackgroundColor = ConsoleColor.Red;
            _console.ForegroundColor = ConsoleColor.White;
            _console.Error.WriteLine(message);
            _console.ResetColor();
        }
    }
}