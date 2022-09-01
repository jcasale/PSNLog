# PowerShell NLog Logging Module

The `PSNLog` module provides logging based on the NLog library.

The *NLog* objects are all built from T4 templates that instantiate the objects using the default constructor and set any properties supplied by the user.

All the common, useful targets are included. No drivers are bundled for the database target.

## Installation

The module is distributed as a Windows Installer package (the PowerShell Gallery is not suitable for some enterprises).

Run the installer manually or in unattended mode:

```bat
msiexec.exe /i ps-nlog.msi /qn
```

The default installation path is:

```bat
%ProgramFiles%\WindowsPowerShell\Modules\PSNLog
```

## Documentation

Use `Get-Command` and `Get-Help` to enumerate the cmdlets with this module and obtain their documentation:

```powershell
Get-Command -Module PSNLog
Get-Help New-NLogLoggingConfiguration -Full
```

## Examples

- Create a basic logger using a sane pattern:

```powershell
try
{
    $name = [IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)
    $path = [IO.Path]::ChangeExtension($MyInvocation.MyCommand.Path, '.log')
    $logger = New-NLogBasicLogger -Name $name -Path $path
}
catch
{
    throw
}

function main
{
    [CmdletBinding()]
    param()

    $logger.Info('Executing script...')

    # Your code follows.
}

try
{
    main -ErrorAction Stop
}
catch
{
    $logger.Fatal($_.Exception, 'Execution failed.')

    throw
}
finally
{
    Stop-NLogLogging
}
```

    > **Warning**
    > Don't call `New-NLogBasicLogger` more than once without shutting down logging by calling `Stop-NLogLogging`.

- Create a logger from XML configuration:

```powershell
New-NLogLoggingConfiguration -Path 'x:\path\NLog.config' |Add-NLogLoggingConfiguration

$logger = Get-NLogLogger MyLogger
$logger.Info('Hello World!')
```