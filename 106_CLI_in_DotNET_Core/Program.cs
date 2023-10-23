using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OrderHubCli
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(Configuration)
                   .Enrich.FromLogContext()
                   .CreateLogger();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(config =>
                    {
                        config.ClearProviders();
                        config.AddProvider(new SerilogLoggerProvider(Log.Logger));
                    });
                    services.AddHttpClient();
                });

            try
            {
                return await builder.RunCommandLineApplicationAsync<OrderHubCmd>(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}

//Exit Code
var arguments = "orderhub list-tickets  --output-format=xml 
--xslt \"C:\orderhubcli\ticket.xsl\" --output \"C:\batchexport\tickets*.txt\"";
Process cmd = new Process();
cmd.StartInfo.FileName = "orderhub.exe";
cmd.StartInfo.Arguments = arguments;
cmd.StartInfo.RedirectStandardInput = false;
cmd.StartInfo.RedirectStandardOutput = false;
cmd.StartInfo.CreateNoWindow = true;
cmd.StartInfo.UseShellExecute = false;
cmd.Start();
cmd.WaitForExit();
if (cmd.ExitCode != 0) //failed
{

}