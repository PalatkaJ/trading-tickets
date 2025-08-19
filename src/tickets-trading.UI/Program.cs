using tickets_trading.Infrastructure;
using tickets_trading.UI.Controller;

namespace tickets_trading.UI;

class Program
{
    static void Main(string[] args)
    {
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();
        
        var authenticationService = ProgramSetup.SetUpAuthenticationService(db);
        var (simpleView, menuView, menuBuilder) = ProgramSetup.SetUpViewsAndBuilders();
        var consoleAppController = new ConsoleAppController(authenticationService, simpleView, menuView, menuBuilder);

        consoleAppController.Run();
    }
}
