# Getting Started with Skyline DataMiner DevOps

Welcome to the wonderful world of the Skyline DataMiner DevOps environment.
Below you'll find a very quick guide on how to get started, this guide is auto-generated based on the initial Project Wizard that was filled in during creation.
For more details and a complete guide then please consider https://docs.dataminer.services/

//#if (CreateDataMinerPackage)
## Creating a Dataminer Application Package

This project was first created in a way that it will create a .dmapp file every time you compile.
To do this, simply compile (or build) the project.
You'll find the created .dmapp in the standard output folder, usually the bin folder of your project.

Take note! Every project that outputs a .dmapp will end up getting published to the Catalog when you decide to publish the entire solution (CI/CD Workflows will do this by default)

//#elseif
## Enable Creation a Dataminer Application Package

This project was first created in a way that it won't create a .dmapp file.

If you're intending to only release this project as a single package then you can double-click and open the $SCRIPTNAME$.csproj file. In there you'll be able to set the <GenerateDataminerPackage> to True.
Alternatively, if you're intending to make a .dmapp file that combined more items than your project you should add a new project called DataMiner Package Project.

Take note! Every project that outputs a .dmapp will end up getting published to the Catalog when you decide to publish the entire solution (CI/CD Workflows will do this by default)

//#endif
## Migrating to a multi-artifact Dataminer Application Package

If you're intending to make a .dmapp file that should combine more items than your initial project you should add a new project called DataMiner Package Project and disable Package Creation for this project.
You can double-click and open the $SCRIPTNAME$.csproj file. In there you'll be able to set the <GenerateDataminerPackage> to False.

After that, right click your solution and select Add>New Project, where you can select the Skyline DataMiner Package Project.