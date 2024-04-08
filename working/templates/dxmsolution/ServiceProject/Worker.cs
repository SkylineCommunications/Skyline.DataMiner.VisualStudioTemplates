namespace $ServiceNameFull$
{
	public class Worker : BackgroundService
	{
	private readonly ILogger<Worker> logger;
	private readonly IConfiguration configuration;
	private readonly IFileSystem filesystem;

	public Worker(ILogger<Worker> logger, IConfiguration configuration)
	{
		this.logger = logger;
		this.configuration = configuration;
		this.filesystem = FileSystem.Instance;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			#region ExampleCode
			// see appsettings.json "WritePath": "C:\\temp\\$DxmModuleName$\\example.txt"
			var path = configuration["File:WritePath"];
			if (String.IsNullOrWhiteSpace(path))
			{
				throw new InvalidOperationException("Path for example file writes cannot be null or empty");
			}

			var directory = filesystem.Path.GetDirectoryName(path);
			if (!filesystem.Directory.Exists(directory)) filesystem.Directory.CreateDirectory(directory);

			filesystem.File.AppendAllText(path, $"{Environment.NewLine + DateTimeOffset.Now}: Worker is running.");
			#endregion

			if (logger.IsEnabled(LogLevel.Information))
			{
				logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
			}
			await Task.Delay(1000, stoppingToken);
		}
	}
	}
}
