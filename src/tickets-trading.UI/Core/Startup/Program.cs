using tickets_trading.Infrastructure.Database;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Core.Startup;

static class Program
{
    static void Main(string[] args)
    {
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();
        
        var authenticationService = ProgramSetup.SetUpAuthenticationService(db);
        var consoleAppController = new ConsoleAppController(authenticationService, new MenuView());

        // I will have to take care of exceptions one day...
        consoleAppController.Run();
    }
}
