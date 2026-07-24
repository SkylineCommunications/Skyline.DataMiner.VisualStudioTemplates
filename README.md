# DataMiner Visual Studio templates

This repository contains DataMiner templates that can be used with Visual Studio and the dotnet CLI.

## Available templates

These Visual Studio templates are currently available.

### Connector solution

A template that creates a new connector Visual Studio solution.

Short name: `dataminer-connector-solution`

### Automation script project

A template that creates a new automation script Visual Studio project.

Short name: `dataminer-automation-project`

### Automation script library project

A template that creates a new automation script library Visual Studio project.

Short name: `dataminer-automation-library-project`

### User-defined API project

A template that creates a new user-defined API Visual Studio project.

Short name: `dataminer-user-defined-api-project`

### GQI ad hoc data source project

A template that creates a new GQI ad hoc data source Visual Studio project.

Short name: `dataminer-gqi-ad-hoc-data-source-project`

### Package project

A template that creates a new DataMiner package Visual Studio project.

Short name: `dataminer-package-project`

> [!TIP]
> This template has an *Integrate with DataMiner Assistant* option (`--integrate-with-dataminer-assistant`) that adds `SetupContent` folders (`adhocs`, `agents`, `scripts`, `skills`) with guidance for integrating the package with the DataMiner Assistant, as well as an `AssistantInstaller.cs` class that is automatically wired into the install entry point to copy those files into the Assistant's context folder on install. It is disabled by default. If you already have an existing package project, then use the [DataMiner Assistant Integration](#dataminer-assistant-integration) item template instead.

### Test package project

A template that creates a new DataMiner test package Visual Studio project.

Short name: `dataminer-test-package-project`

## Available item templates

Unlike the project templates listed above, item templates add files to an existing project rather than creating a new project.

### DataMiner Assistant Integration

An item template that adds `SetupContent` folders (`adhocs`, `agents`, `scripts`, `skills`) with guidance for integrating an existing DataMiner package project with the DataMiner Assistant, as well as an `AssistantInstaller.cs` class. Run it from the root of the package project.

Since this template adds files to an existing project, it cannot safely edit your existing install entry point. After it had run, do the following:

1. Make sure the project references the `Skyline.DataMiner.Utils.SecureCoding` NuGet package (`AssistantInstaller.cs` uses its secure path helpers): `dotnet add package Skyline.DataMiner.Utils.SecureCoding`.
1. Add one line to your `Install(IEngine engine, AppInstallContext context)` method (right after `installer.InstallDefaultContent();`):

   ```csharp
   AssistantInstaller.InstallAssistantFiles(installer);
   ```

The template prints these instructions after generation as a reminder.

Short name: `dataminer-assistant-integration`

## Installation

As of version 2.42, DataMiner Integration Studio (DIS) automatically installs the latest template package when you open Visual Studio. If you do not have this version of DIS, then follow these steps:

1. Install the latest version of [.NET](https://dot.net).
1. Run 'dotnet new install Skyline.DataMiner.VisualStudioTemplates' to install the templates.

> [!NOTE]
> If you have not used DIS before and want to find out all about this extension for Microsoft Visual Studio, visit our [DIS expert Hub](https://community.dataminer.services/exphub-dis/) on DataMiner Dojo for more detailed information, downloads, and more.

## Usage

### Using Visual Studio

1. Select DataMiner from the project type selection box.
1. Select the template you want to install, and follow the instructions.

![Visual Studio New Project Window](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/images/VisualStudio-NewProject.png)

Item templates (e.g., DataMiner Assistant Integration) are added to an existing project instead. Right-click the target project in *Solution Explorer*, and select *Add* > *New Item*. Then select the template from the DataMiner category.

### Using the CLI

1. Choose a template (i.e., `dataminer-automation-project`).
1. Run `dotnet new dataminer-automation-project --help` to see the available options.
1. Run `dotnet new dataminer-automation-project` with the required options along with any other options to create a project from the template.

For item templates, run the equivalent command from the target project's root directory (e.g., `dotnet new dataminer-assistant-integration` from the root of an existing package project).

## How to contribute

To add additional templates, create a new template, and put it under the working/templates folder. For more information about how to create a template, see [Custom templates for dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates).

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/LICENSE). See the file for details.
