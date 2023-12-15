namespace $PackageId$
{
    using System.CommandLine;
    using System.Threading.Tasks;

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
            var exampleArgument = new Option<string>(
                name: "--example-argument",
                description: "Just an example argument.")
            {
                IsRequired = true
            };

            var rootCommand = new RootCommand("$PackageDescription$")
            {
                exampleArgument,
            };

            rootCommand.SetHandler(Process, exampleArgument);

            await rootCommand.InvokeAsync(args);

            return 0;
        }

        private static async Task Process(string exampleArgument)
        {
            //Main Code for program here
        }
    }
}