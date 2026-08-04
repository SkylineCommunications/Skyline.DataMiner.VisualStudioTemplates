param (
    [Parameter(Mandatory = $true)]
    [string]$PathToTestPackageContent
)

$ErrorActionPreference = 'Stop'

# Import common code module
Import-Module -Name (Join-Path $PSScriptRoot 'CommonCode.psm1')

$pathToTestHarvesting = Join-Path $PathToTestPackageContent 'TestHarvesting'
$pathToGeneratedTests = Join-Path $pathToTestHarvesting 'tests.generated'
$pathToGeneratedDependencies = Join-Path $pathToTestHarvesting 'dependencies.generated'
$pathToTests = Join-Path $PathToTestPackageContent 'Tests'
$pathToDependencies = Join-Path $PathToTestPackageContent 'Dependencies'
# Optional directory that may contain supplementary files passed in the QAOps test-run request.
# This directory may not exist when no supplementary files were provided, so never assume that it
# or any specific file inside it is available.
# The QAOps Bridge also extracts the same files to an agent-local directory on EVERY agent of the
# cluster and exposes that path through the QAOPS_SUPPLEMENTARY_FILES machine environment variable.
# Use that variable from code that may execute on another agent (for example an Automation script):
#   [Environment]::GetEnvironmentVariable('QAOPS_SUPPLEMENTARY_FILES', 'Machine')
$pathToSupplementaryFiles = Join-Path $PathToTestPackageContent 'SupplementaryFiles'

# Track script start time
$scriptStart = Get-Date

try {
    Write-Host "Running Test Package tests..." -ForegroundColor Cyan
    
    <#
        This is a placeholder for where the test execution logic would go.
    #>

    # Send OK result indicating that test package execution has finished successfully
    Push-TestCaseResult -Outcome 'OK' -Name "pipeline_TestPackageExecution" -Duration ((Get-Date) - $scriptStart) -Message "Test Package execution finished." -TestAspect Execution
} catch {
    Push-TestCaseResult -Outcome 'Fail' -Name "pipeline_TestPackageExecution" -Duration ((Get-Date) - $scriptStart) -Message "Exception during Test Package execution: $($_.Exception.Message)" -TestAspect Execution
    exit 1
}