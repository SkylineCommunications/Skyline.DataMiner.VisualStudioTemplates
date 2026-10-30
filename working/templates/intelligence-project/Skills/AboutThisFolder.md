# Skills

Store reusable DataMiner Intelligence skill instructions in this folder.

Create a new skill with the `dataminer-intelligence-skill-file` template. Skill files contain focused instructions that can be reused by Intelligence agents.

## Visual Studio

Right-click this folder in Solution Explorer, select **Add** > **New Item**, choose the DataMiner Intelligence Skill File template, and select **Add**.

## .NET CLI

Run this command from the directory containing the project `.csproj` file:

```bash
dotnet new dataminer-intelligence-skill-file --name my-skill --output Skills
```
