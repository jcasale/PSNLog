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
        HelpMessage = "Gets or sets the name of the connection string (as specified in <connectionStrings> configuration section.")]
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

        if (this.CommandProperties is { Length: > 0 })
        {
            foreach (var item in this.CommandProperties)
            {
                instance.CommandProperties.Add(item);
            }
        }

        if (this.CommandText is not null)
        {
            instance.CommandText = this.CommandText;
        }

        if (this.CommandType.HasValue)
        {
            instance.CommandType = this.CommandType.Value;
        }

        if (this.ConnectionProperties is { Length: > 0 })
        {
            foreach (var item in this.ConnectionProperties)
            {
                instance.ConnectionProperties.Add(item);
            }
        }

        if (this.ConnectionString is not null)
        {
            instance.ConnectionString = this.ConnectionString;
        }

        if (this.ConnectionStringName is not null)
        {
            instance.ConnectionStringName = this.ConnectionStringName;
        }

        if (this.DBDatabase is not null)
        {
            instance.DBDatabase = this.DBDatabase;
        }

        if (this.DBHost is not null)
        {
            instance.DBHost = this.DBHost;
        }

        if (this.DBPassword is not null)
        {
            instance.DBPassword = this.DBPassword;
        }

        if (this.DBProvider is not null)
        {
            instance.DBProvider = this.DBProvider;
        }

        if (this.DBUserName is not null)
        {
            instance.DBUserName = this.DBUserName;
        }

        if (this.InstallConnectionString is not null)
        {
            instance.InstallConnectionString = this.InstallConnectionString;
        }

        if (this.InstallDdlCommands is { Length: > 0 })
        {
            foreach (var item in this.InstallDdlCommands)
            {
                instance.InstallDdlCommands.Add(item);
            }
        }

        if (this.IsolationLevel.HasValue)
        {
            instance.IsolationLevel = this.IsolationLevel.Value;
        }

        if (this.KeepConnection.HasValue)
        {
            instance.KeepConnection = this.KeepConnection.Value;
        }

        if (this.Name is not null)
        {
            instance.Name = this.Name;
        }

        if (this.Parameters is { Length: > 0 })
        {
            foreach (var item in this.Parameters)
            {
                instance.Parameters.Add(item);
            }
        }

        if (this.UninstallDdlCommands is { Length: > 0 })
        {
            foreach (var item in this.UninstallDdlCommands)
            {
                instance.UninstallDdlCommands.Add(item);
            }
        }

        this.WriteObject(instance);
    }
}
