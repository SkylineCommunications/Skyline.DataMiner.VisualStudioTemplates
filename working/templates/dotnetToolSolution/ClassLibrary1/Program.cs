namespace $PackageId$
{
    using System.CommandLine;
    using System.Threading.Tasks;

    /// <summary>
    /// $PackageDescription$.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Code that will be called when running the tool.
        /// </summary>
        /// <param name="args">Extra arguments.</param>
        /// <returns>0 if successful.</returns>
        public static async Task<int> Main(string[] args)
        {
            var exampleArgument = new Option<string>(
                name: "--exampleArgument",
                description: "Just an example argument.")
            {
                IsRequired = true
            };

            var rootCommand = new RootCommand("$PackageDescription$")
            {
                exampleArgument,
            };

            rootCommand.SetHandler(Process, exampleArgument);

            return await rootCommand.InvokeAsync(args);
        }

        private static async Task Process(string exampleArgument)
        {
            //Main Code for program here
        }
    }
}