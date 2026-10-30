# AdHoc

Store DataMiner Intelligence ad hoc data source definitions in this folder.

Create a new data source with the `dataminer-intelligence-data-source-file` template. Data source files define the data and input arguments exposed by an ad hoc data source.

## Visual Studio

Right-click this folder in Solution Explorer, select **Add** > **New Item**, choose the DataMiner Intelligence Data Source File template, and select **Add**.

## .NET CLI

Run this command from the directory containing the project `.csproj` file:

```bash
dotnet new dataminer-intelligence-data-source-file --name my-data-source --output AdHoc
```
