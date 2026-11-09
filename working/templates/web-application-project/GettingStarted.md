# Getting Started with a DataMiner Web Application Project

This project contains a DataMiner web application: a standalone (static) web site that fully runs in the browser.

## App.info.json

The `App.info.json` file in the root of the project describes the web application. The following fields are mandatory:

- `ID`: A unique GUID that identifies the web application. A new GUID was generated when this project was created.
- `Name`: The name of the web application.
- `Color`: The color of the web application.
- `Icon`: The icon of the web application.

Optionally, you can also specify fields such as `Description`, `DefaultDocument`, `Manifest`, and `Sections`.

## Developing

Node.js and npm are required on the development machine.

- `npm run dev` starts a local development server.
- `npm run build` builds the web application to the `dist` folder.

## Building and deploying

A web application doesn't produce its own DataMiner package. To deploy it, include it in a DataMiner package project (`dataminer-package-project`). By default, the `PackageContent/ProjectReferences.xml` file of a package project includes all `.csproj` and `.esproj` projects in the solution.

When the package project is built, the web application is built as well. Its output folder (`dist`, as configured by the `BuildOutputFolder` property) is zipped together with `App.info.json` and added to the generated `.dmapp` package. The web application is imported when the package is installed on a DataMiner System.

To zip another folder, change the `BuildOutputFolder` property in the `.esproj` file.

For more information, visit [DataMiner Docs](https://docs.dataminer.services/).
