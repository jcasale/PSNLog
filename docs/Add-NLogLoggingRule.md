---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# Add-NLogLoggingRule

## SYNOPSIS

Adds the specified logging rule to the specified configuration.

## DESCRIPTION

The Add-NLogLoggingRule cmdlet adds the specified logging rule to the existing collection of rules in the specified configuration.

## EXAMPLES

### Example 1: Create a rule.

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
Add-NLogLoggingConfiguration $configuration
```

This example creates a rule for a console target.