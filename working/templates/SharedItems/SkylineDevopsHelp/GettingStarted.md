# Getting Started with Skyline DataMiner DevOps

Welcome to the Skyline DataMiner DevOps environment!  
This quick-start guide will help you get up and running. It was auto-generated based on the initial project setup during creation.  
For more details and comprehensive instructions, please visit [DataMiner Docs](https://docs.dataminer.services/).

<!--#if (CreateDataMinerPackage)-->
## Creating a DataMiner Application Package

This project was configured to create a `.dmapp` file every time you build the project.  
When you compile or build the project, you will find the generated `.dmapp` in the standard output folder, typically the `bin` folder of your project.

When Publishing (see Publishing topic below), this project will become its own item on the online DataMiner Catalog.

<!--#else-->
## Enabling the Creation of a DataMiner Application Package

This project was not configured to generate a `.dmapp` file.  
To enable `.dmapp` generation, consider migrating to a multi-artifact DataMiner Application Package as described below.

<!--#endif-->
## Migrating to a Multi-Artifact DataMiner Application Package

If you need to combine additional components in your `.dmapp` file, you should:

1. Open the `$SCRIPTNAME$.csproj` file and ensure the `<GenerateDataminerPackage>` property is set to `False`.
2. Right-click your solution and select **Add > New Project**.
3. Select the **Skyline DataMiner Package Project** template.

Follow the provided **Getting Started** guide in the new project for further instructions.

<!--#if (IsCatalogNoCICD)-->
## Publishing to the Catalog

This project was created with support for publishing to the DataMiner Catalog.  
You can publish your artifact either manually via the Visual Studio IDE or by setting up a CI/CD workflow.

### Manual Publishing

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register Catalog items**
   - **Read Catalog items**

1. Securely store the key using Visual Studio User Secrets:
   - Right-click the project and select **Manage User Secrets**.
   - Add the key in the following format:

    ```json
    {
      "skyline": {
        "sdk": {
          "Catalogpublishtoken": "MyKeyHere"
        }
      }
    }
    ```

1. Publish the package by right clicking your project in Visual Studio and then selecting the **Publish** option. This will open a new window, where you'll find a Publish button and a link where your item will eventually be registered.

### Changing The Version

- Navigate to your project in Visual Studio, right click and select properties

- Search for Package Version

- You can now adjust this value

### Changing The Version - Alternative

- Navigate and double click on your project in Visual Studio.

- Adjust the XML tag Version to the version you want to register.

```xml
<Version>1.0.0.1</Version>
```

**Recommendation:** For stable releases, consider using a CI/CD setup to run **dotnet publish** only after passing quality checks.

<!--#elseif (IsCatalogBasicCICD)-->
## Publishing to the Catalog with Basic CI/CD Workflow

This project includes a basic GitHub workflow for Catalog publishing.  
Follow these steps to set it up:

1. Create a GitHub repository. Via **Git > Create Git Repository**, Selecting GitHub and filling in the wizard before clicking **Create and Push**.

1. On GitHub, go to the *Actions* tab.

1. Click on the workflow run that failed (usually called *Add project files*)

1. Click on the "build" step that failed and read the failing error

``` text
Error: DATAMINER_TOKEN is not set. Release not possible!
Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
Navigate to the right Organization then go to Keys and create/find a key with permissions to Register Catalog Items.
Copy the value of the token.
Then set a DATAMINER_TOKEN secret in your repository settings: **Dynamic Link**
```

You can use the links from the actual error to better address the next couple of steps.

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register Catalog items**
   - **Read Catalog items**

1. Add the key as a secret in your GitHub repository:
   - Navigate to **Settings > Secrets and variables > Actions** and create a secret named `DATAMINER_TOKEN`.
1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

### Releasing a Specific Version

- Navigate to the **<> Code** tab in your GitHub repository.
- Select **Releases** from the right-hand menu.
- Create a new release, select the desired version as a **Tag**, and provide a title and description.

> [!NOTE]
> The description will be visible on the DataMiner Catalog.

<!--#elseif (IsCatalogCompleteCICD)-->

## Publishing to the Catalog with Complete CI/CD Workflow

This project includes a comprehensive GitHub workflow that adheres to Skyline Communications' quality standards, including static code analysis, custom validation, and unit testing.

### Prerequisite:  
You need a **SonarCloud Organization**. If you don’t have one, you can create it [here](https://sonarcloud.io/create-organization).

### Steps:

1. Create a GitHub repository. Via **Git > Create Git Repository**, Selecting GitHub and filling in the wizard before clicking **Create and Push**.

1. On GitHub, go to the *Actions* tab.

1. Click on the workflow run that failed (usually called *Add project files*)

1. Click on the "build" step that failed and read the failing error

``` text
Error: DATAMINER_TOKEN is not set. Release not possible!
Please create or re-use an admin.dataminer.services token by visiting: https://admin.dataminer.services/.
Navigate to the right Organization then go to Keys and create/find a key with permissions to Register Catalog Items.
Copy the value of the token.
Then set a DATAMINER_TOKEN secret in your repository settings: **Dynamic Link**
```

You can use the links from the actual error to better address the next couple of steps.

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register Catalog items**
   - **Read Catalog items**

1. Add the key as a secret in your GitHub repository:
   - Navigate to **Settings > Secrets and variables > Actions** and create secrets or variables with the required names.
1. Re-run the workflow.

The following secrets and variables will have been added to your repository after all issues are resolved:

| Name            | Type    | Description                                        | Setup Guide                                                                                 |
|-----------------|---------|----------------------------------------------------|---------------------------------------------------------------------------------------------|
| `DATAMINER_TOKEN` | Secret  | Organization key for publishing to the Catalog   | Obtain from [admin.dataminer.services](https://admin.dataminer.services/) and add it as a secret. |
| `SONAR_TOKEN`    | Secret  | Token for SonarCloud authentication               | Obtain from [SonarCloud Security](https://sonarcloud.io/account/security) and add it as a secret.  |
| `SONAR_NAME`     | Variable | SonarCloud project ID                            | Visit [SonarCloud](https://sonarcloud.io/projects/create), copy the project ID, and add it as a variable. |

### Releasing a Version

- Navigate to the **<> Code** tab in your GitHub repository.
- Select **Releases** from the right-hand menu.
- Create a new release, select the desired version as a **Tag**, and provide a title and description.

> [!NOTE]
> The description will be visible on the DataMiner Catalog.

<!--#else-->
## Enabling Publishing to the Catalog

This project was created without support for publishing to the DataMiner Catalog.  
To enable this, add a **Skyline DataMiner Package Project** to your solution and follow the **Getting Started** guide provided in that project.

<!--#endif-->