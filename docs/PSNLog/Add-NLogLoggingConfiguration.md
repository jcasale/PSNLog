---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: Add-NLogLoggingConfiguration
---

# Add-NLogLoggingConfiguration

## SYNOPSIS

Adds the specified configuration to the current logging configuration.

## SYNTAX

### __AllParameterSets

```
Add-NLogLoggingConfiguration [-Configuration] <LoggingConfiguration> [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION

The Add-NLogLoggingConfiguration cmdlet adds the specified configuration instance to the static `NLog.LogManager.Configuration` property.

The cmdlet will throw if an existing configuration is already set. Use the Stop-NLogLogging cmdlet to shut down logging before setting a new configuration.

## EXAMPLES

### Example 1: Add a configuration to the static `NLog.LogManager.Configuration` property

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

This example creates a basic configuration with a console target and adds it to the static `NLog.LogManager.Configuration` property.

## PARAMETERS

### -Configuration

Specifies the configuration to apply.

```yaml
Type: NLog.Config.LoggingConfiguration
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 0
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -PassThru

Returns the configuration object. By default, this cmdlet does not generate any output.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### NLog.Config.LoggingConfiguration

You can pipe an **NLog.Config.LoggingConfiguration** object to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingConfiguration

When you use the **PassThru** parameter, this cmdlet returns the **NLog.Config.LoggingConfiguration** object. Otherwise, this cmdlet does not generate any output.

## NOTES

## RELATED LINKS
