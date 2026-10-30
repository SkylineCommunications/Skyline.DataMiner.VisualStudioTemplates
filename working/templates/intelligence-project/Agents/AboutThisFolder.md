# Agents

Store DataMiner Intelligence agent definitions in this folder.

Create a new agent with the `dataminer-intelligence-agent-file` template. Agent files contain instructions and metadata for an Intelligence agent.

## Visual Studio

Right-click this folder in Solution Explorer, select **Add** > **New Item**, choose the DataMiner Intelligence Agent File template, and select **Add**.

## .NET CLI

Run this command from the directory containing the project `.csproj` file:

```bash
dotnet new dataminer-intelligence-agent-file --name my-agent --output Agents
```
