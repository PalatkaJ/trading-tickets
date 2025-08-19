using tickets_trading.Application;
using tickets_trading.Infrastructure;
using tickets_trading.UI.View;
using tickets_trading.UI.View.Menu;
using tickets_trading.UI.View.Menu.MenuBuilders;

namespace tickets_trading.UI;

public static class ProgramSetup
{
    public static AuthenticationModule SetUpAuthenticationService(AppDbContext db)
    {
        var userRepo = new UserRepository(db);
        var hasher = new Pbkdf2PasswordHasher();
        return new AuthenticationModule(userRepo, hasher);
    }
}