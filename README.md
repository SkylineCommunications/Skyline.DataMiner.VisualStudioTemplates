# DataMiner Visual Studio templates

This repository contains DataMiner templates that can be used with Visual Studio and the dotnet CLI.

## Available templates

The following section lists the currently available Visual Studio templates.

### Connector solution

Template that creates a new connector Visual Studio solution.

Short name: `dataminer-connector-solution`

### Automation script project

Template that creates a new Automation script Visual Studio project.

Short name: `dataminer-automation-project`

### Automation script library project

Template that creates a new Automation script library Visual Studio project.

Short name: `dataminer-automation-library-project`

### User-defined API project

Template that creates a new User-Defined API Visual Studio project.

Short name: `dataminer-user-defined-api-project`

### GQI ad hoc data source project

Template that creates a new GQI ad hoc data source Visual Studio project.

Short name: `dataminer-gqi-ad-hoc-data-source-project`

### Package project

Template that creates a new DataMiner package Visual Studio project.

Short name: `dataminer-package-project`

> **Tip**
> This template has an *Integrate with DataMiner Assistant* option (`--integrate-with-dataminer-assistant`) that adds `SetupContent` folders (`adhocs`, `agents`, `scripts`, `skills`) with guidance for integrating the package with the DataMiner Assistant. It is disabled by default. Already have an existing package project? Use the [DataMiner Assistant Integration](#dataminer-assistant-integration) item template instead.

### Test package project

Template that creates a new DataMiner test package Visual Studio project.

Short name: `dataminer-test-package-project`

## Available item templates

Unlike the project templates above, item templates add files to an existing project rather than creating a new project.

### DataMiner Assistant Integration

Item template that adds `SetupContent` folders (`adhocs`, `agents`, `scripts`, `skills`) with guidance for integrating an existing DataMiner package project with the DataMiner Assistant. Run it from the root of the package project.

Short name: `dataminer-assistant-integration`

## How to install

As of version 2.42, DataMiner Integration Studio (DIS) automatically installs the latest template package when you open Visual Studio. If you don't have this version of DIS, then follow these steps:

1. Install the latest [.NET](https://dot.net)
2. Run 'dotnet new install Skyline.DataMiner.VisualStudioTemplates' to install the templates.

> **Note**
> *New to DIS?* If you haven’t used DIS before and want to find out all about this extension for Microsoft Visual Studio, visit our  [DIS expert Hub](https://community.dataminer.services/exphub-dis/) on DataMiner Dojo for more detailed information, downloads, and more.

## How to use

### Using Visual Studio

1. Select DataMiner from the project type drop down.
2. Select the template you want to install and follow the instructions.

![Visual Studio New Project Window](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/images/VisualStudio-NewProject.png)

Item templates (e.g. DataMiner Assistant Integration) are added to an existing project instead: right-click the target project in *Solution Explorer* and select *Add* > *New Item*, then select the template from the DataMiner category.

### Using the CLI

1. Choose a template i.e. `dataminer-automation-project`.
2. Run `dotnet new dataminer-automation-project --help` to see the available options.
3. Run `dotnet new dataminer-automation-project` with the required options along with any other options to create a project from the template.

For item templates, run the equivalent command from the target project's root directory, e.g. `dotnet new dataminer-assistant-integration` from the root of an existing package project.

## How to contribute

To add additional templates, create a new template and put it under the working/templates folder. For more information about how to create a template, refer to [Custom templates for dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates).

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/LICENSE). See the file for details.
