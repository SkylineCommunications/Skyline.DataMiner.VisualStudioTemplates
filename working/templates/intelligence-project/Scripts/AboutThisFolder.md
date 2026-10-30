# Scripts

Store DataMiner Intelligence script definitions in this folder.

Create a new script with the `dataminer-intelligence-script-file` template. Script files define the script metadata, inputs, and execution behavior.

## Visual Studio

Right-click this folder in Solution Explorer, select **Add** > **New Item**, choose the DataMiner Intelligence Script File template, and select **Add**.

## .NET CLI

Run this command from the directory containing the project `.csproj` file:

```bash
dotnet new dataminer-intelligence-script-file --name my-script --output Scripts
```
