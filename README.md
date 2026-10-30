# DataMiner Visual Studio templates

This repository contains DataMiner templates that can be used with Visual Studio and the dotnet CLI.

## Available templates

The following section lists the currently available templates.

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

### Test package project

Template that creates a new DataMiner test package Visual Studio project.

Short name: `dataminer-test-package-project`

### Scripted connector project

Creates a Python based connector script project.

Language: Python

Short name: `dataminer-connector-script`

### Intelligence project

Template that creates a new DataMiner Intelligence project.

Short name: `dataminer-intelligence-project`

### Intelligence agent file

Template that creates a new DataMiner Intelligence agent file.

Short name: `dataminer-intelligence-agent-file`

### Intelligence data source file

Template that creates a new DataMiner Intelligence data source file.

Short name: `dataminer-intelligence-data-source-file`

### Intelligence DOM file

Template that creates a new DataMiner Intelligence DOM file.

Short name: `dataminer-intelligence-dom-file`

### Intelligence script file

Template that creates a new DataMiner Intelligence script file.

Short name: `dataminer-intelligence-script-file`

### Intelligence skill file

Template that creates a new DataMiner Intelligence skill file.

Short name: `dataminer-intelligence-skill-file`

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

### Using the CLI

1. Choose a project template i.e. `dataminer-automation-project`.
2. Run `dotnet new dataminer-automation-project --help` to see the available options.
3. Run `dotnet new dataminer-automation-project` with the required options along with any other options to create a project from the template.

## How to contribute

To add additional templates, create a new template and put it under the working/templates folder. For more information about how to create a template, refer to [Custom templates for dotnet new](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates).

### Copy a PR to the Internal templates repository

Both template repositories are publicly accessible. "Public" refers to `Skyline.DataMiner.VisualStudioTemplates`, whose templates are intended for external users; "Internal" refers to `Skyline.DataMiner.VisualStudioTemplates.Internal`, whose templates are intended for Skyline employees. These labels describe the intended audience, not repository visibility.

Maintainers can run the **Copy PR to Internal templates** workflow from the Actions tab on this repository's default branch. Enter the source PR number; the workflow applies that PR's file changes to a new branch based on `Skyline.DataMiner.VisualStudioTemplates.Internal`'s `main` and opens an Internal PR for review. It does not merge the PR or copy unrelated source files.

Configure an Actions secret named `VS_TEMPLATES_REPO_TOKEN` in both template repositories (or share an organization secret with both). Use a single fine-grained **personal access token** scoped to `Skyline.DataMiner.VisualStudioTemplates` and `Skyline.DataMiner.VisualStudioTemplates.Internal`, with **Contents: Read and write**, **Pull requests: Read and write**, and **Agent tasks: Read and write** permissions. Also grant **Workflows: Read and write** when copying changes to GitHub Actions workflow files. The token's owner must be able to push branches, create PRs, and use Copilot cloud agent in both repositories. GitHub App installation tokens do not support the Copilot agent tasks API.

If applying the source PR's patch fails (for example, because of a conflict), the workflow instead starts a Copilot cloud-agent task in Internal to apply the changes and create a PR. The workflow summary links to the task; Copilot works asynchronously, so the PR may appear later and must be reviewed for Internal-specific adaptations. The workflow still fails without invoking Copilot if the changes are already present or if a checkout, push, or GitHub API call fails. The agent tasks API is in public preview and can change.

For the reverse direction, run **Copy PR to Public templates** in `Skyline.DataMiner.VisualStudioTemplates.Internal` with an Internal PR number. Confirm that the selected changes are suitable for external users before running it.

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/LICENSE). See the file for details.
