# Dom

Store DataMiner Object Model definitions used by DataMiner Intelligence in this folder.

Create a new DOM definition with the `dataminer-intelligence-dom-file` template. DOM files describe the module, definition, and fields for a DOM definition.

## Visual Studio

Right-click this folder in Solution Explorer, select **Add** > **New Item**, choose the DataMiner Intelligence DOM File template, and select **Add**.

## .NET CLI

Run this command from the directory containing the project `.csproj` file:

```bash
dotnet new dataminer-intelligence-dom-file --name my-dom --output Dom
```
