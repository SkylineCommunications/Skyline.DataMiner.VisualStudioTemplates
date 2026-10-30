# Getting Started with a DataMiner Intelligence Project

This project is ready for you to add DataMiner Intelligence artifacts.

## Adding Intelligence artifacts

### Using Visual Studio

1. Right-click the correct folder node in Solution Explorer.
2. Select **Add** > **New Item**.
3. Select the appropriate DataMiner Intelligence template.
4. Enter the artifact name and select **Add**.

Select the destination folder for the artifact before opening **Add** > **New Item**:

- `Agents` for Agent files
- `AdHoc` for Data Source files
- `Dom` for DOM files
- `Scripts` for Script files
- `Skills` for Skill files

### Using the .NET CLI

Run the command from the directory that contains the project's `.csproj` file and pass the destination folder with `--output`. For example, to create an Agent file:

```bash
cd path/to/your/intelligence-project
dotnet new dataminer-intelligence-agent-file --name my-agent --output Agents
```

Use the corresponding project folder for each template:

- `Agents`: `dataminer-intelligence-agent-file`
- `AdHoc`: `dataminer-intelligence-data-source-file`
- `Dom`: `dataminer-intelligence-dom-file`
- `Scripts`: `dataminer-intelligence-script-file`
- `Skills`: `dataminer-intelligence-skill-file`

## Building and deploying

Build the project to validate the Intelligence artifacts.

If **Create DataMiner Package** was enabled when the project was created, the build also generates a DataMiner application package. The generated `.dmapp` file is available in the standard build output folder.

You can deploy the generated package to a DataMiner Agent using the normal DataMiner deployment workflow.

If **Create DataMiner Package** was disabled, the project still builds and validates the Intelligence artifacts, but it does not produce a deployable `.dmapp` file. Create a new project with **Create DataMiner Package** enabled when you need package generation.

For more information, visit [DataMiner Docs](https://docs.dataminer.services/).