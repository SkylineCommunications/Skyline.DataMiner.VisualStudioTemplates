# $FullDxmName$

## About

$PackageDescription$

## Projects

* For more information about the service $FullDxmName$, see [$ServiceName$/README.md]($ServiceName$/README.md).
* For more information about the installer $FullDxmName$, see [$InstallerName$/README.md]($InstallerName$/README.md).
* For more information about the API $FullDxmName$, see [$NuGetName$/README.md]($NuGetName$/README.md).

### About DataMiner Extension Modules

A DataMiner Extension Module (DxM) is a service that can be installed, upgraded and uninstalled, possibly on a DataMiner agent, without using an upgrade package or introducing any down time of the DMA.

### Requirements

* A DataMiner Extension Module must be deployable with a single MSI installer.

* The MSI installer should have correct default values so it can be executed unattended for installations and upgrades.

* The module should be written in the latest .NET LTS version (currently .NET 6, soon .NET 8(?)) so it's also possible to install them on a Linux machine.

* It must be possible for the module to be installed on 0 or any number of machines in the cluster.

* The module must use the message broker for all communication to other processes.

* The module must not care about how many instances of the module are running in the cluster, it should be as stateless as possible.

* The module must not depend on any dataminer files on the local disk, as the module must be deployable on any machine even without dataminer installation, only being given a connection to the message broker.

* The module must have its own release versioning, so that new versions can be released without releasing new dataminer versions.

* Add the logs of your DxM in the LogCollector tool output

    * Open the SLLogCollector folder from the server repo in Visual Studio Code

    * Find all on FieldControl or any other common known DxM to find what changes you most likely need to do

For more information please see the [Internal Docs](https://internaldocs.skyline.be/DevDocs/DataMiner_Extension_Modules/Overview.html)

<!-- Uncomment below and add more info to provide more information about how to use this specific DxM. -->
<!-- ## Getting Started -->
