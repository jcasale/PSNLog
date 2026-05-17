# https://learn.microsoft.com/en-us/powershell/utility-modules/platyps/overview

Install-Module Microsoft.PowerShell.PlatyPS -Scope CurrentUser

Import-Module .\publish\PSNLog.psd1

# Create new command help files.
Get-Module PSNLog |New-MarkdownCommandHelp -OutputFolder .\docs

# Test the help files.
Get-ChildItem .\docs\PSNLog\*.md |
    Import-MarkdownCommandHelp |
    ForEach-Object {
        $title = $_.Title
        $_.Diagnostics.Messages |ForEach-Object {
            [PSCustomObject][ordered]@{
                Title = $title
                Severity = $_.Severity
                Message = $_.Message
                Identifier = $_.Identifier
            }
        }
    } |
    Where-Object { $_.Severity -eq 'Error' -or $_.Severity -eq 'Warning' }

# Update the help files.
Measure-PlatyPSMarkdown -Path .\docs\PSNLog\*.md |
    Where-Object Filetype -match 'CommandHelp' |
    Update-MarkdownCommandHelp -Path {$_.FilePath}

# Convert and publish the help files.
Measure-PlatyPSMarkdown -Path .\docs\PSNLog\*.md |
    Where-Object Filetype -match 'CommandHelp' |
    Import-MarkdownCommandHelp -Path {$_.FilePath} |
    Export-MamlCommandHelp -OutputFolder .\maml -Force