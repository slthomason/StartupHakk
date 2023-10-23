using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace OrderHubCli
{
    [Command(Name = "orderhub", ThrowOnUnexpectedArgument = false, OptionsComparison
     = System.StringComparison.InvariantCultureIgnoreCase)]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(
        typeof(LoginCmd),
        typeof(ListTicketCmd))]
    class OrderHubCmd : OrderHubCmdBase
    {
        public OrderHubCmd(ILogger<OrderHubCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            // this shows help even if the --help option isn't specified
            app.ShowHelp();
            return Task.FromResult(0);
        }

        private static string GetVersion()
            => typeof(OrderHubCmd).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            .InformationalVersion;
    }
}