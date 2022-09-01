[CmdletBinding()]
param
(
    [Parameter(Position=0)]
    [string]
    $Path = (Join-Path $PSScriptRoot 'PSNlog.psd1'),
    [Parameter(Position=1)]
    [Version]
    $Version
)

Set-StrictMode -Version Latest

if (Test-Path $Path)
{
    Remove-Item $Path -Force
}

if ($null -eq $Version)
{
    try
    {
        $result = & git.exe describe --tags --abbrev=0
    }
    catch
    {
        throw
    }

    if ($LASTEXITCODE -ne 0)
    {
        throw
    }

    $softwareVersion = $result.Split('-')[0].TrimStart('v')

    Write-Verbose ('Using git version {0}.' -f $softwareVersion)
}
else
{
    $softwareVersion = $Version.ToString()

    Write-Verbose ('Using specified version {0}.' -f $softwareVersion)
}

$content = @'
@{{
  RootModule = 'PSNLog.dll'
  ModuleVersion = '{0}'
  GUID = '407659af-362f-47f3-946b-fc0cf70a94ce'
  Author = 'Joseph L. Casale'
  CompanyName = 'Joseph L. Casale'
  Copyright = '(c) Joseph L. Casale. All rights reserved.'
  Description = 'A PowerShell module for logging based on the NLog library.'
  RequiredAssemblies = @('NLog.dll', 'NLog.Database.dll')
  NestedModules = @()
  FunctionsToExport = @()
  CmdletsToExport = @(
    'Add-NLogLoggingConfiguration',
    'Add-NLogLoggingRule',
    'Add-NLogTarget',
    'Get-NLogLogger',
    'Get-NLogLoggingConfiguration',
    'New-AsyncTargetWrapper',
    'New-BufferingTargetWrapper',
    'New-NLogBasicLogger',
    'New-NLogColoredConsoleTarget',
    'New-NLogConsoleRowHighlightingRule',
    'New-NLogConsoleTarget',
    'New-NLogConsoleWordHighlightingRule',
    'New-NLogDatabaseCommandInfo',
    'New-NLogDatabaseParameterInfo',
    'New-NLogDatabaseTarget',
    'New-NLogEventLogTarget',
    'New-NLogFileTarget',
    'New-NLogLoggingConfiguration',
    'New-NLogLoggingRule',
    'New-NLogMailTarget',
    'Remove-NLogLoggingRule',
    'Remove-NLogTarget',
    'Stop-NLogLogging'
  )
  VariablesToExport = @()
  AliasesToExport = @()
  PrivateData = @{{ PSData = @{{}} }}
}}
'@ -f $softwareVersion

Set-Content -Value $content -Path $Path