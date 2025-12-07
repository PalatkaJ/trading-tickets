using tickets_shop.Infrastructure.Database;
using tickets_shop.UI.Features.UIServices.Menu;

namespace tickets_shop.UI.Core.Startup;

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
