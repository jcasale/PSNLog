namespace Tests;

using System.Threading;
using System.Threading.Tasks;

using SmtpServer;
using SmtpServer.Authentication;

public class TestUserAuthenticator : UserAuthenticator
{
    public override Task<bool> AuthenticateAsync(ISessionContext context, string user, string password, CancellationToken cancellationToken)
        => Task.FromResult(true);
}