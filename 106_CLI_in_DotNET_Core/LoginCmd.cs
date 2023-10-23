using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrderHubCli
{
    [Command(Name = "login", 
    Description = "login to orderhub, the login crendentials will be saved locally in the profile")]
    class LoginCmd : OrderHubCmdBase
    {

        [Option(CommandOptionType.SingleValue, ShortName = "u",
         LongName = "username", Description = "orderhub login username", ValueName = "login username", 
         ShowInHelpText = true)]
        public string Username { get; set; }

        [Option(CommandOptionType.SingleValue, ShortName = "p", 
        LongName = "password", Description = "orderhub login password", 
        ValueName = "login password", ShowInHelpText = true)]
        public string Password { get; set; }

        [Option(CommandOptionType.NoValue, LongName = "staging", 
        Description = "orderhub staging api", ValueName = "staging", ShowInHelpText = true)]
        public bool Staging { get; set; } = false;

        public LoginCmd(ILogger<LoginCmd> logger, IConsole console, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _console = console;
            _httpClientFactory = clientFactory;
        }
        private OrderHubCmd Parent { get; set; }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Username = Prompt.GetString("OrderHub Username:", Username);
                Password = SecureStringToString(Prompt.GetPasswordAsSecureString("OrderHub Password:"));
                Staging = Prompt.GetYesNo("Order Staging?   ", Staging);
                Profile = Prompt.GetString("User profile name:", Profile);
                OutputFormat = Prompt.GetString("Output format (json|xml|text|table):", OutputFormat);
            }

            try
            {
                var userProfile = new UserProfile()
                {
                    Username = Username,
                    Password = Encrypt(Password),
                    Staging = Staging,
                    OutputFormat = OutputFormat
                };

                if (!Directory.Exists(ProfileFolder))
                {
                    Directory.CreateDirectory(ProfileFolder);
                }

                await File.WriteAllTextAsync($"{ProfileFolder}{Profile}", JsonConvert.SerializeObject(userProfile, Formatting.Indented), UTF8Encoding.UTF8);

                var token = await OrderHubClient.GetTokenAsync();

                return 0;

            }
            catch (Exception ex)
            {
                OnException(ex);
                return 1;
            }
        }
    }
}