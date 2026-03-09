$ErrorActionPreference = 'Stop'

$pathToGeneratedTests = Join-Path $PSScriptRoot 'tests.generated'
$pathToGeneratedDependencies = Join-Path $PSScriptRoot 'dependencies.generated'
$pathToXmlAutomationTests = Join-Path $PSScriptRoot 'xmlautomationtests.generated'

# Clean up any previous output
if (Test-Path $pathToGeneratedTests) {
    Remove-Item -Recurse -Force $pathToGeneratedTests
}

if (Test-Path $pathToGeneratedDependencies) {
    Remove-Item -Recurse -Force $pathToGeneratedDependencies
}

if (Test-Path $pathToXmlAutomationTests) {
    Remove-Item -Recurse -Force $pathToXmlAutomationTests
}

New-Item -ItemType Directory -Force -Path $pathToGeneratedTests  | Out-Null
New-Item -ItemType Directory -Force -Path $pathToGeneratedDependencies  | Out-Null
New-Item -ItemType Directory -Force -Path $pathToXmlAutomationTests  | Out-Null

<#
    This is a placeholder for where the test discovery logic would go.
    This could include scanning for test files, generating test manifests, etc.
#>

# Warning, do not cleanup the collected files here. Next step in the SDK will use these.
Write-Information "`n🎉 Script completed successfully!"
exit 0
