---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Remove-NLogTarget

## SYNOPSIS

Removes a target.

## DESCRIPTION

The Remove-NLogTarget cmdlet removes a target from the specified configuration either by name or reference.

## EXAMPLES

### Example 1: Removes a target by reference.

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogColoredConsoleTarget -Name ConsoleTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name ConsoleRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Remove-NLogTarget -Configuration $configuration -Rule $rule
```

This example creates a basic configuration with a console target, then removes the target by reference.