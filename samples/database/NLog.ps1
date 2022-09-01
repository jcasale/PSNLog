New-NLogLoggingConfiguration -Path '.\NLog.config' |Add-NLogLoggingConfiguration

$logger = Get-NLogLogger 'XmlDatabaseLogger'
$logger.Info('Hello World!')