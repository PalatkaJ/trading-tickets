using tickets_trading.Application;
using tickets_trading.Application.Authentication;
using tickets_trading.Infrastructure;
using tickets_trading.Infrastructure.Authentication;
using tickets_trading.Infrastructure.Database;

namespace tickets_trading.UI.Core.Startup;

public static class ProgramSetup
{
    public static AuthenticationModule SetUpAuthenticationService(AppDbContext db)
    {
        var userRepo = new UserRepository(db);
        var hasher = new Pbkdf2PasswordHasher();
        return new AuthenticationModule(userRepo, hasher);
    }
}