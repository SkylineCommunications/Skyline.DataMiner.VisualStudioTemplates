namespace $PackageId$.Commands
{
    using $PackageId$.SystemCommandLine;

    internal class ExampleCommand : Command
    {
        public ExampleCommand() : 
            base(name: "example", description: "An example of a subcommand.")
        {
            AddOption(new Option<IFileInfoIO>(
                aliases: ["--example-package-file", "-epf"],
                description: "The path to the example package file that is mandatory and needs to exist.",
                parseArgument: OptionHelper.ParseFileInfo!)
            {
                IsRequired = true
            }.LegalFilePathsOnly()!.ExistingOnly());

            AddOption(new Option<IDirectoryInfoIO?>(
                aliases: ["--example-output-directory", "-eod"],
                description: "The directory path for the output which is optional.",
                parseArgument: OptionHelper.ParseDirectoryInfo)
            {
                IsRequired = false
            }.LegalFilePathsOnly());

            AddOption(new Option<bool?>(
                aliases: ["--show-extra-message", "-sem"],
                description: "When provided, it will show an additional message."));
        }
    }
    
    internal class ExampleCommandHandler(ILogger<ExampleCommandHandler> logger, IConfiguration configuration) : ICommandHandler
    {
        /*
         * Automatic binding with System.CommandLine.NamingConventionBinder
         * The property names need to match with the command line argument names.
         * Example: --example-package-file will bind to ExamplePackageFile
         */

        public required IFileInfoIO ExamplePackageFile { get; set; }

        public IDirectoryInfoIO? ExampleOutputDirectory { get; set; }

        public bool? ShowExtraMessage { get; set; }

        public int Invoke(InvocationContext context)
        {
            // InvokeAsync is called in Program.cs
            return (int)ExitCodes.NotImplemented;
        }

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            logger.LogDebug("Starting {method}...", nameof(ExampleCommand));

            try
            {
                // Retrieve user secrets/environment variables
                var exampleSecret = configuration["ExampleSecret"];

                // Create output directory if exists
                ExampleOutputDirectory?.Create();

                // Readout file if not too large
                if (ExamplePackageFile.Length < 10000)
                {
                    using StreamReader sr = ExamplePackageFile.OpenText();
                    string fileContent = await sr.ReadToEndAsync(context.GetCancellationToken());
                    logger.LogInformation("Full file:{newLine}{content}", Environment.NewLine, fileContent);
                }
                else
                {
                    logger.LogWarning("File is too large to read out for this example command. Size: {size}", ExamplePackageFile.Length);
                }

                if (ShowExtraMessage is true)
                {
                    logger.LogInformation("Extra informational message that will be shown.");
                }

                return (int)ExitCodes.Ok;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Failed the example command.");
                return (int)ExitCodes.UnexpectedException;
            }
            finally
            {
                logger.LogDebug("Finished {method}.", nameof(ExampleCommand));
            }
        }
    }
}