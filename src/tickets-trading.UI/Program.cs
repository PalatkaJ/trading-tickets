using System.Diagnostics;
using tickets_trading.Application;
using tickets_trading.Infrastructure;

namespace tickets_trading.UI;

class Program
{
    static void Main(string[] args)
    {
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();
        
        var authService = ProgramSetup.SetUpAuthenticationService(db);
        var consoleAppController = new ConsoleAppController(authService);

        consoleAppController.Run();
    }
}
