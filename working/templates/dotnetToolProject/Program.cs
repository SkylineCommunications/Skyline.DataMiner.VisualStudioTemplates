namespace $PackageId$
{
    using System.CommandLine;
    using System.Threading.Tasks;

    /// <summary>
    /// Checks what projects are Legacy style or SDK Style.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// $PackageDescription$.
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

            await rootCommand.InvokeAsync(args);

            return 0;
        }

        private static async Task Process(string exampleArgument)
        {
            //Main Code for program here
        }
    }
}