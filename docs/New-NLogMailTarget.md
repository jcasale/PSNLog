---
external help file: PSNLog.dll-Help.xml
Module Name: PSNLog
online version:
schema: 2.0.0
---

# New-NLogMailTarget

## SYNOPSIS

Creates a mail target.

## DESCRIPTION

The New-NLogMailTarget cmdlet creates a mail target.

## EXAMPLES

### Example 1: Create a mail target.

```powershell
$configuration = New-NLogLoggingConfiguration
$target = New-NLogMailTarget `
  -From sender@domain.com `
  -To recipient@domain.com `
  -SmtpPort 25000 `
  -SmtpServer mail.domain.com `
  -Name MailTarget
$rule = New-NLogLoggingRule `
  -Target $target `
  -Name MailRule `
  -LoggerNamePattern * `
  -MinLevel Trace `
  -MaxLevel Fatal
Add-NLogLoggingRule -Configuration $configuration -Rule $rule
Add-NLogLoggingConfiguration $configuration
$logger = Get-NLogLogger -Name MyLogger
```

This example creates a logger with a mail target.