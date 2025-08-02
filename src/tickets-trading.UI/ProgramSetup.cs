using tickets_trading.Application;
using tickets_trading.Infrastructure;

namespace tickets_trading.UI;

public static class ProgramSetup
{
    public static AuthService SetUpAuthenticationService(AppDbContext db)
    {
        var userRepo = new UserRepository(db);
        var hasher = new Pbkdf2PasswordHasher();
        return new AuthService(userRepo, hasher);
    } 
}