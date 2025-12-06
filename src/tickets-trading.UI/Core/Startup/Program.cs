using tickets_trading.Infrastructure.Database;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Menu;

namespace tickets_trading.UI.Core.Startup;

static class Program
{
    static void Main(string[] args)
    {
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();

        var (userRepo, eventsRepo, ticketsRepo) = ProgramSetup.InitializeRepositories(db);
        var authenticationService = ProgramSetup.SetUpAuthenticationService(userRepo);
        var consoleAppController = new ConsoleAppController(authenticationService, new MenuService(), userRepo, eventsRepo, ticketsRepo, db);
        
        consoleAppController.Run();
    }
}
