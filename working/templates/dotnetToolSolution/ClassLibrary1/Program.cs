namespace $PackageId$
{
    using System;
    using System.CommandLine;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using Serilog;

    /// <summary>
    /// $PackageDescription$.
    /// </summary>
    public static class Program
    {
        /*
         * Design guidelines for command line tools: https://learn.microsoft.com/en-us/dotnet/standard/commandline/syntax#design-guidance
         */

        /// <summary>
        /// Code that will be called when running the tool.
        /// </summary>
        /// <param name="args">Extra arguments.</param>
        /// <returns>0 if successful.</returns>
        public static async Task<int> Main(string[] args)
        {
            var isDebug = new Option<bool>(
            name: "--debug",
            description: "Indicates the tool should write out debug logging.")
            {
                IsRequired = false,
            };

            isDebug.SetDefaultValue(false);

            var exampleArgument = new Option<string>(
                name: "--example-argument",
                description: "Just an example argument.")
            {
                IsRequired = true
            };

            var rootCommand = new RootCommand("$PackageDescription$")
            {
                isDebug,
                exampleArgument,
            };

            rootCommand.SetHandler(Process, isDebug, exampleArgument);

            return await rootCommand.InvokeAsync(args);
        }

        private static async Task<int> Process(bool isDebug, string exampleArgument)
        {
            try
            {
                var logConfig = new LoggerConfiguration().WriteTo.Console();
                logConfig.MinimumLevel.Is(isDebug ? Serilog.Events.LogEventLevel.Debug : Serilog.Events.LogEventLevel.Information);
                var seriLog = logConfig.CreateLogger();

                using var loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog(seriLog));
                var logger = loggerFactory.CreateLogger("$PackageId$");
                try
                {
                    //Main Code for program here
                }
                catch (Exception e)
                {
                    logger.LogError($"Exception during Process Run: {e}");
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception on Logger Creation: {e}");
                return 1;
            }

            return 0;
        }
    }
}