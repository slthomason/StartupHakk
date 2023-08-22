using System.CommandLine;
using ZipCreator;

public class Program
{
    [STAThread]
    static public async Task<int> Main(string[] args)
    {
        var inputFileArg = new Argument<FileInfo>(
            name: "input",
            description: "Zip file manifest containing glob patterns of file paths to include"
        );

        var outputFileArg = new Argument<FileInfo>(
            name: "output",
            description: "Path to zip file output"
        );

        var forceOption = new Option<bool>(
            name: "--force",
            getDefaultValue: () => false,
            description: "Overwrite output file if it exists"
        );

        var verboseOption = new Option<bool>(
            name: "--verbose",
            getDefaultValue: () => false,
            description: "Show verbose log statements"
        );

        var rootCommand = new RootCommand("Create a zip via a manifest file containing glob pattern rules");
        rootCommand.AddArgument(inputFileArg);
        rootCommand.AddArgument(outputFileArg);
        rootCommand.AddOption(forceOption);
        rootCommand.AddOption(verboseOption);

        Action<FileInfo, FileInfo, bool, bool> handler = (inputFile, outputFile, force, verbose) =>
        {
            Console.WriteLine(inputFile.FullName);
            Console.WriteLine(inputFile.FullName);
            Console.WriteLine(force.ToString());
            Console.WriteLine(verbose.ToString());
        };

        rootCommand.SetHandler(handler, inputFileArg, outputFileArg, forceOption, verboseOption);

        return await rootCommand.InvokeAsync(args);
    }
}