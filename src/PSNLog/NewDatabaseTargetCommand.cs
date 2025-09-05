namespace PSNLog;

using System.Management.Automation;

[Cmdlet(VerbsCommon.New, "NLogDatabaseTarget")]
[OutputType(typeof(NLog.Targets.DatabaseTarget))]
public class NewDatabaseTargetCommand : PSCmdlet
{
    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the collection of properties. Each item contains a mapping between NLog layout and a property on the DbCommand instance.")]
    public NLog.Targets.DatabaseObjectPropertyInfo[] CommandProperties { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the text of the SQL command to be run on each log level.")]
    public NLog.Layouts.Layout CommandText { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the type of the SQL command to be run on each log level.")]
    public System.Data.CommandType? CommandType { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the collection of properties. Each item contains a mapping between NLog layout and a property on the DbConnection instance.")]
    public NLog.Targets.DatabaseObjectPropertyInfo[] ConnectionProperties { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the connection string. When provided, it overrides the values specified in DBHost, DBUserName, DBPassword, DBDatabase.")]
    public NLog.Layouts.Layout ConnectionString { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the connection string (as specified in https://msdn.microsoft.com/en-us/library/bf7sd233.aspx <connectionStrings> configuration section.")]
    public string ConnectionStringName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database name. If the ConnectionString is not provided this value will be used to construct the 'Database=' part of the connection string.")]
    public NLog.Layouts.Layout DBDatabase { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database host name. If the ConnectionString is not provided this value will be used to construct the 'Server=' part of the connection string.")]
    public NLog.Layouts.Layout DBHost { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database password. If the ConnectionString is not provided this value will be used to construct the 'Password=' part of the connection string.")]
    public NLog.Layouts.Layout DBPassword { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the database provider.")]
    public string DBProvider { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the database user name. If the ConnectionString is not provided this value will be used to construct the 'User ID=' part of the connection string.")]
    public NLog.Layouts.Layout DBUserName { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the connection string using for installation and uninstallation. If not provided, regular ConnectionString is being used.")]
    public NLog.Layouts.Layout InstallConnectionString { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the installation DDL commands.")]
    public NLog.Targets.DatabaseCommandInfo[] InstallDdlCommands { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Configures isolated transaction batch writing. If supported by the database, then it will improve insert performance.")]
    public System.Data.IsolationLevel? IsolationLevel { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets a value indicating whether to keep the database connection open between the log events.")]
    public bool? KeepConnection { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets or sets the name of the target.")]
    public string Name { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the collection of parameters. Each item contains a mapping between NLog layout and a database named or positional parameter.")]
    public NLog.Targets.DatabaseParameterInfo[] Parameters { get; set; }

    [Parameter(
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "Gets the uninstallation DDL commands.")]
    public NLog.Targets.DatabaseCommandInfo[] UninstallDdlCommands { get; set; }

    protected override void ProcessRecord()
    {
        var instance = new NLog.Targets.DatabaseTarget();

        if (CommandProperties is { Length: > 0 })
        {
            foreach (var item in CommandProperties)
            {
                instance.CommandProperties.Add(item);
            }
        }

        if (CommandText is not null)
        {
            instance.CommandText = CommandText;
        }

        if (CommandType.HasValue)
        {
            instance.CommandType = CommandType.Value;
        }

        if (ConnectionProperties is { Length: > 0 })
        {
            foreach (var item in ConnectionProperties)
            {
                instance.ConnectionProperties.Add(item);
            }
        }

        if (ConnectionString is not null)
        {
            instance.ConnectionString = ConnectionString;
        }

        if (ConnectionStringName is not null)
        {
            instance.ConnectionStringName = ConnectionStringName;
        }

        if (DBDatabase is not null)
        {
            instance.DBDatabase = DBDatabase;
        }

        if (DBHost is not null)
        {
            instance.DBHost = DBHost;
        }

        if (DBPassword is not null)
        {
            instance.DBPassword = DBPassword;
        }

        if (DBProvider is not null)
        {
            instance.DBProvider = DBProvider;
        }

        if (DBUserName is not null)
        {
            instance.DBUserName = DBUserName;
        }

        if (InstallConnectionString is not null)
        {
            instance.InstallConnectionString = InstallConnectionString;
        }

        if (InstallDdlCommands is { Length: > 0 })
        {
            foreach (var item in InstallDdlCommands)
            {
                instance.InstallDdlCommands.Add(item);
            }
        }

        if (IsolationLevel.HasValue)
        {
            instance.IsolationLevel = IsolationLevel.Value;
        }

        if (KeepConnection.HasValue)
        {
            instance.KeepConnection = KeepConnection.Value;
        }

        if (Name is not null)
        {
            instance.Name = Name;
        }

        if (Parameters is { Length: > 0 })
        {
            foreach (var item in Parameters)
            {
                instance.Parameters.Add(item);
            }
        }

        if (UninstallDdlCommands is { Length: > 0 })
        {
            foreach (var item in UninstallDdlCommands)
            {
                instance.UninstallDdlCommands.Add(item);
            }
        }

        WriteObject(instance);
    }
}
