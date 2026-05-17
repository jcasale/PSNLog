---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: Add-NLogTarget
---

# Add-NLogTarget

## SYNOPSIS

Adds the specified logging target to the specified configuration.

## SYNTAX

### __AllParameterSets

```
Add-NLogTarget [-Target] <Target> [-Configuration] <LoggingConfiguration> [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION

The Add-NLogTarget cmdlet adds the specified logging target to the existing collection of targets in the specified configuration.

## EXAMPLES

### Example 1: Add a target to a configuration

```powershell
$configuration = New-NLogLoggingConfiguration
$consoleTarget = New-NLogColoredConsoleTarget -Name ConsoleTarget
Add-NLogTarget -Target $consoleTarget -Configuration $configuration
```

This example adds a console target to the configuration.

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

### -Target

Specifies the target to add.

```yaml
Type: NLog.Targets.Target
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

### NLog.Targets.Target

You can pipe an **NLog.Targets.Target** object to this cmdlet.

### NLog.Config.LoggingConfiguration

You can pipe an **NLog.Config.LoggingConfiguration** object to this cmdlet.

## OUTPUTS

### NLog.Config.LoggingConfiguration

When you use the **PassThru** parameter, this cmdlet returns the **NLog.Config.LoggingConfiguration** object. Otherwise, this cmdlet does not generate any output.

## NOTES

## RELATED LINKS
