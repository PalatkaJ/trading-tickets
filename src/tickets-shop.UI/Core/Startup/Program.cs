using tickets_shop.Infrastructure.Database;
using tickets_shop.UI.Features.UIServices.Menu;

namespace tickets_shop.UI.Core.Startup;

/// <summary>
/// The main entry point class for the application.
/// It is responsible for initializing the database, setting up the application's
/// services and dependencies, and starting the main application controller loop.
/// </summary>
static class Program
{
    /// <summary>
    /// The main method executed when the application starts.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    static void Main(string[] args)
    {
        // 1. Database Initialization
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated(); // Creates the SQLite file and schema if it doesn't exist.

        // 2. Dependency Setup (Composition Root)
        // Initializes all concrete repository implementations
        var (userRepo, eventsRepo, ticketsRepo) = ProgramSetup.InitializeRepositories(db);
        
        // Initializes the authentication service with the user repository
        var authenticationService = ProgramSetup.SetUpAuthenticationService(userRepo);
        
        // Initializes the main application controller with all dependencies
        var consoleAppController = new ConsoleAppController(authenticationService, new MenuService(), userRepo, eventsRepo, ticketsRepo, db);
        
        // 3. Application Start
        consoleAppController.Run(); // Starts the main console application loop.
    }
}