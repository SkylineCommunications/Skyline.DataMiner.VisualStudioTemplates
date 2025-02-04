# Getting Started with Skyline DataMiner DevOps

Welcome to the Skyline DataMiner DevOps environment!  
This quick-start guide will help you get up and running.  
For more details and comprehensive instructions, please visit [DataMiner Docs](https://docs.dataminer.services/).

<!--#if (CreateDataMinerPackage)-->
## Creating a DataMiner Application Package

This project is configured to create a `.dmapp` file every time you build the project.  
Simply compile or build the project, and you will find the generated `.dmapp` in the standard output folder, typically the `bin` folder of your project.

When publishing, this project will become its own item on the online catalog.

## The DataMiner Package Project

This project is designed to create multi-artifact packages in a straightforward manner.

### Adding New Artifacts in the Same Solution

You can right-click the solution and select Add and then New Project. This will allow you to select other DataMiner Project Templates. (e.g. adding additional Automation Scripts)
Important: Connectors are currently not supported.

Every **Skyline.DataMiner.SDK** project, except other DataMiner Package Projects, will by default be included within the `.dmapp` created by this project.  
You can customize this behavior using the **PackageContent/ProjectReferences.xml** file. This allows you to add filters to include or exclude projects as needed.

### Adding Content from the Catalog

You can reference and include additional content from the catalog using the **PackageContent/CatalogReferences.xml** file provided in this project.

### Importing from DataMiner

You can import specific items directly from a DataMiner agent:  

1. Connect to an agent via **Extensions > DIS > DMA > Connect**.
1. If your agent is not present, you can add a new agent via **Extensions > DIS > Settings**, and selecting Add on the DMA tab.
1. Once connected, you can import specific DataMiner artifacts.
1. Navigate to folders such as **PackageContent/Dashboards** or **PackageContent/LowCodeApps**, right-click, select **Add**, and choose **Import DataMiner Dashboard/LowCodeApp** or the equivalent.

## Execute Additional Code on Installation

Open the **$SCRIPTNAME$.cs** file to write custom installation code. Common actions include creating elements, services, or views.

**Quick Tip:** Type `clGetDms` in the `.cs` file and press **Tab** twice to insert a snippet that gives you access to the **IDms** classes, making DataMiner manipulation easier.

## Does Your Installation Code Need Configuration Files?

You can add configuration files (e.g. `.json`, `.xml`) to the **SetupContent** folder, which can be accessed during installation.

Access them in your code using:
```csharp
string setupContentPath = installer.GetSetupContentDirectory();
```

<!--#else-->
## Enabling the Creation of a DataMiner Application Package

**OOPS!** This project is not configured to generate a `.dmapp` file.  
If you intended to create a `.dmapp` file, you may have set up the project incorrectly.

Please consider the following options:

- Remove this project and create a new DataMiner Application Project with `.dmapp` generation enabled.
- If you don’t require `.dmapp` creation, review your project setup to ensure it aligns with your goals.
<!--#endif-->

<!--#if (IsCatalogNoCICD)-->
## Publishing to the Catalog

This project was created with support for publishing to the DataMiner catalog.  
You can publish your artifact manually through Visual Studio or by setting up a CI/CD workflow.

### Manual Publishing

1. Obtain an **Organization Key** from [admin.dataminer.services](https://admin.dataminer.services/) with the following scopes:
   - **Register catalog items**
   - **Read catalog items**
   
2. Securely store the key using Visual Studio User Secrets:
   - Right-click the project and select **Manage User Secrets**.
   - Add the key in the following format:

    ```json
    {
      "skyline": {
        "sdk": {
          "catalogpublishtoken": "MyKeyHere"
        }
      }
    }
    ```

3. Publish the package by right clicking your project in Visual Studio and then selecting the **Publish** option. This will open a new window, where you'll find a Publish button and a link where your item will eventually be registered.

### Releasing a Specific Version

- Navigate to your project in Visual Studio, right click and select properties

- Search for Package Version

- You can now adjust this value

### Releasing a Specific Version - Alternative

- Navigate and double click on your project in Visual Studio.

- Adjust the XML tag Version to the version you want to register.

```xml
<Version>1.0.0.1</Version>
```

**Recommendation:** For stable releases, consider using a CI/CD setup to run **dotnet publish** only after passing quality checks.

<!--#elseif (IsCatalogBasicCICD)-->
## Publishing to the Catalog with Basic CI/CD Workflow

This project includes a basic GitHub workflow for catalog publishing.  
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
   - **Register catalog items**
   - **Read catalog items**

1. Add the key as a secret in your GitHub repository:
   - Navigate to **Settings > Secrets and variables > Actions** and create a secret named `DATAMINER_TOKEN`.
1. Re-run the workflow.

With this setup, any push with new content (including the initial creation) to the main/master branch will generate a new pre-release version, using the latest commit message as the version description.

### Releasing a Specific Version

- Navigate to the **<> Code** tab in your GitHub repository.
- Select **Releases** from the right-hand menu.
- Create a new release, select the desired version as a **Tag**, and provide a title and description. (The description will be visible in the catalog.)

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
   - Navigate to **Settings > Secrets and variables > Actions** and create a secret named `DATAMINER_TOKEN`.
1. Re-run the workflow.

The following secrets and variables will have been added to your repository after all issues are resolved:

| Name            | Type    | Description                                        | Setup Guide                                                                                 |
|-----------------|---------|----------------------------------------------------|---------------------------------------------------------------------------------------------|
| `DATAMINER_TOKEN` | Secret  | Organization key for publishing to the Catalog   | Obtain from [admin.dataminer.services](https://admin.dataminer.services/) and add it as a secret. |
| `SONAR_TOKEN`    | Secret  | Token for SonarCloud authentication               | Obtain from [SonarCloud Security](https://sonarcloud.io/account/security) and add it as a secret.  |
| `SONAR_NAME`     | Variable | SonarCloud project ID                            | Visit [SonarCloud](https://sonarcloud.io/projects/create), copy the project ID, and add it as a variable. |

### Releasing a Version

- Navigate to the **<> Code** tab in your repository.
- Select **Releases** from the right-hand menu.
- Draft a new release, select the desired version, and provide a description.

<!--#else-->
## Enabling Catalog Publishing

**OOPS!** This project was created without support for catalog publishing.  
If you intended to publish to the catalog, you may have set up the project incorrectly.

Please consider the following options:
1. Remove this project and create a new DataMiner Application Project with `.dmapp` creation and catalog support enabled.
2. If catalog publishing is not required, review your project setup to ensure it aligns with your goals.

<!--#endif-->