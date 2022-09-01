[CmdletBinding()]
param
(
    [Parameter(Position=0)]
    [string]
    $Path = (Join-Path $PSScriptRoot 'version.props'),
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
        $result = & git.exe describe HEAD --tags --long
    }
    catch
    {
        throw
    }

    if ($LASTEXITCODE -ne 0)
    {
        throw
    }

    $informationalVersion = $result.TrimStart('v')
    $softwareVersion = $informationalVersion.Split('-')[0]

    Write-Verbose ('Using git version {0}.' -f $softwareVersion)
}
else
{
    $informationalVersion = $Version.ToString()
    $softwareVersion = $Version.ToString()

    Write-Verbose ('Using specified version {0}.' -f $softwareVersion)
}

$content = @'
<Project>
  <PropertyGroup>
    <AssemblyVersion>{0}</AssemblyVersion>
    <FileVersion>{0}</FileVersion>
    <Version>{0}</Version>
    <InformationalVersion>{1}</InformationalVersion>
  </PropertyGroup>
</Project>
'@ -f $softwareVersion, $informationalVersion

Set-Content -Value $content -Path $Path