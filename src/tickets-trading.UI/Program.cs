using tickets_trading.Infrastructure;
using tickets_trading.UI.Controller;
using tickets_trading.UI.View.Menu;

namespace tickets_trading.UI;

class Program
{
    static void Main(string[] args)
    {
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();
        
        var authenticationService = ProgramSetup.SetUpAuthenticationService(db);
        var consoleAppController = new ConsoleAppController(authenticationService, new MenuView());

        consoleAppController.Run();
    }
}
