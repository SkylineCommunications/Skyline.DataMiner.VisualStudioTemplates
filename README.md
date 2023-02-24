# DataMiner Visual Studio Templates

This repository contains DataMiner templates that can be used with Visual Studio and the dotnet CLI.

## Solution Templates

### NuGet Solution

Visual Studio template that creates a Solution containing pre-filled meta-data to handle NuGet creation.

### NuGet Project

Visual Studio template that creates a Project containing pre-filled meta-data to handle NuGet creation.

## How to install


1. Install the latest [.NET](https://dot.net)
2. Run 'dotnet new install Skyline.DataMiner.VisualStudioTemplates' to install the templates.

> [!NOTE]
> In the future, the above will be done automatically by DataMiner Integration Studio.

## How to use

### Using Visual Studio

1. Select DataMiner from the project type drop down.
2. Select the template you want to install and follow the instructions.

![Visual Studio New Project Window](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/images/VisualStudio-NewProject.png)

### Using the CLI

1. Choose a project template i.e. `dataminer-srmfunction-solution`.
2. Run `dotnet new dataminer-srmfunction-solution --help` to see the available options.
3. Run `dotnet new dataminer-srmfunction-solution ' with the required options along with any other options to create a solution from the template.

## How to contribute

To add additional templates, create a new template and put it under the templates folder. For more information about how to create a template, refer to [Custom templates for dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates).

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/LICENSE). See the file for details.
