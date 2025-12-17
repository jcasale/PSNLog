namespace Tests;

using SmtpServer;
using SmtpServer.Authentication;

internal sealed class TestUserAuthenticator : UserAuthenticator
{
    public override Task<bool> AuthenticateAsync(ISessionContext context, string user, string password, CancellationToken cancellationToken)
        => Task.FromResult(true);
}