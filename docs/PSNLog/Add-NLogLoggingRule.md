---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 06-13-2026
PlatyPS schema version: 2024-05-01
title: Add-NLogLoggingRule
---

# Add-NLogLoggingRule

## SYNOPSIS

Adds the specified logging rule to the specified configuration.

## SYNTAX

### __AllParameterSets

```
Add-NLogLoggingRule [-Rule] <LoggingRule> [-Configuration] <LoggingConfiguration> [-PassThru]
 [<CommonParameters>]
```

## ALIASES

None.


## DESCRIPTION

The Add-NLogLoggingRule cmdlet adds the specified logging rule to the existing collection of rules in the specified configuration.

## EXAMPLES

### Example 1: Create a rule

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

## PARAMETERS

### -Configuration

Specifies the configuration to update.

```yaml
Type: NLog.Config.LoggingConfiguration
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: 1
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

### -Rule

Specifies the rule to add.

```yaml
Type: NLog.Config.LoggingRule
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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### NLog.Config.LoggingConfiguration

You can pipe the configuration to update.

### NLog.Config.LoggingRule

You can pipe the rule to add.

## OUTPUTS

### NLog.Config.LoggingConfiguration

Returns the updated logging configuration when you use the **PassThru** parameter. Otherwise, this cmdlet does not generate any output.

## NOTES

## RELATED LINKS
