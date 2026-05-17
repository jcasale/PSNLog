---
document type: cmdlet
external help file: PSNLog.dll-Help.xml
HelpUri: ''
Locale: en-US
Module Name: PSNLog
ms.date: 05-17-2026
PlatyPS schema version: 2024-05-01
title: New-NLogEventLogTarget
---

# New-NLogEventLogTarget

## SYNOPSIS

Creates a Windows Event Log target.

## SYNTAX

### __AllParameterSets

```
New-NLogEventLogTarget [-Category <Layout`1[short]>] [-EntryType <Layout`1[EventLogEntryType]>]
 [-EventId <Layout`1[int]>] [-Layout <Layout>] [-Log <Layout>] [-MachineName <Layout>]
 [-MaxKilobytes <Layout`1[long]>] [-MaxMessageLength <Layout`1[int]>] [-Name <string>]
 [-OnOverflow <EventLogTargetOverflowAction>] [-Source <Layout>] [<CommonParameters>]
```

## DESCRIPTION

The New-NLogEventLogTarget cmdlet creates a Windows Event Log target.

## EXAMPLES

### Example 1: Create an Event Log target

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogEventLogTarget -Source MySource -Name EventLogTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name EventLogRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger.WithProperty('EventID', 42).Info('Hello World!')
```

This example creates a logger with an Event Log target.

## PARAMETERS

### -Category

Gets or sets the layout that renders event Category.

```yaml
Type: NLog.Layouts.Layout`1[System.Int16]
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -EntryType

Optional entry type. When not set, or when not convertible to T:System.Diagnostics.EventLogEntryType then determined by T:NLog.LogLevel.

```yaml
Type: NLog.Layouts.Layout`1[System.Diagnostics.EventLogEntryType]
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -EventId

Gets or sets the layout that renders event ID.

```yaml
Type: NLog.Layouts.Layout`1[System.Int32]
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Layout

Gets or sets the layout used to format log messages.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Log

Gets or sets the name of the Event Log to write to. This can be System, Application or any user-defined name.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MachineName

Gets or sets the name of the machine on which Event Log service is running.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MaxKilobytes

Gets or sets the maximum Event log size in kilobytes.

```yaml
Type: NLog.Layouts.Layout`1[System.Int64]
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -MaxMessageLength

Gets or sets the message length limit to write to the Event Log.

```yaml
Type: NLog.Layouts.Layout`1[System.Int32]
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

Gets or sets the name of the target.

```yaml
Type: System.String
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -OnOverflow

Gets or sets the action to take if the message is larger than the P:NLog.Targets.EventLogTarget.MaxMessageLength option.

```yaml
Type: System.Nullable`1[NLog.Targets.EventLogTargetOverflowAction]
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: true
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Source

Gets or sets the value to be used as the event Source.

```yaml
Type: NLog.Layouts.Layout
DefaultValue: ''
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
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

### NLog.Layouts.Layout`1[[System.Int16

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout`1[[System.Diagnostics.EventLogEntryType

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout`1[[System.Int32

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout

You can pipe an **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout`1[[System.Int64

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### System.String

You can pipe a string to this cmdlet.

### NLog.Targets.EventLogTargetOverflowAction

You can pipe an **EventLogTargetOverflowAction** value to this cmdlet.

### NLog.Layouts.Layout`1[[System.Int16, System.Private.CoreLib, Version=11.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout`1[[System.Diagnostics.EventLogEntryType, System.Diagnostics.EventLog, Version=11.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51]]

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout`1[[System.Int32, System.Private.CoreLib, Version=11.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

### NLog.Layouts.Layout`1[[System.Int64, System.Private.CoreLib, Version=11.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

You can pipe a typed **NLog.Layouts.Layout** object to this cmdlet.

## OUTPUTS

### NLog.Targets.EventLogTarget

This cmdlet returns an **NLog.Targets.EventLogTarget** object.

## NOTES

## RELATED LINKS
