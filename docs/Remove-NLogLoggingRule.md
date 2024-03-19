---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Remove-NLogLoggingRule

## SYNOPSIS

Removes a logging a rule.

## DESCRIPTION

The Remove-NLogLoggingRule cmdlet removes a logging rule from the specified configuration either by name or reference.

## EXAMPLES

### Example 1: Removes a rule by reference.

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
Remove-NLogLoggingRule -Configuration $configuration -Rule $rule
```

This example creates a basic configuration with a console target, then removes the rule by reference.