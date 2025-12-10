using Microsoft.EntityFrameworkCore;
using tickets_shop.UI.Features.UIServices.Menu;
using tickets_shop.Application.Authentication;
using tickets_shop.Application.DatabaseAPI;

namespace tickets_shop.UI.Core.Startup;

/// <summary>
/// The main execution controller for the console application.
/// It sets up the application state, initializes all lazy menu builders, and runs
/// the primary display/input/action loop.
/// </summary>
public class ConsoleAppController
{
    private readonly ApplicationState? _applicationState;

    /// <summary>
    /// Configures the ApplicationState with the initial menu builder and essential context services.
    /// </summary>
    /// <param name="menuService">The service managing menu display and option selection.</param>
    /// <param name="context">The database context instance.</param>
    private void InitializeAppStateMenu(MenuService menuService, DbContext context)
    {
        // Sets the initial screen to the Authentication Menu.
        _applicationState!.MenuBuilder = LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value;

        _applicationState.MenuService = menuService;
        _applicationState.MenuService.MenuBuilder = _applicationState.MenuBuilder;
        
        _applicationState.DbContext = context;
    }

    /// <summary>
    /// Configures the ApplicationState with all core repository dependencies.
    /// </summary>
    private void InitializeAppStateRepositories(IUserRepository userRepo, IEventsRepository eventsRepo, ITicketsRepository ticketsRepo)
    {
        _applicationState!.UserRepository = userRepo;
        _applicationState.EventsRepository = eventsRepo;
        _applicationState.TicketsRepository = ticketsRepo;
    }
    
    /// <summary>
    /// Initializes the application controller, creates the ApplicationState, and
    /// wires up all required dependencies (MenuService, Repositories, DbContext).
    /// </summary>
    public ConsoleAppController(IAuthenticationModule authenticationModule, MenuService menuService,
        IUserRepository userRepo, IEventsRepository eventsRepo, ITicketsRepository ticketsRepo, DbContext context)
    {
        _applicationState = new();
        
        LazyMenuBuildersLibrary.Initialize(_applicationState, authenticationModule);
        
        InitializeAppStateMenu(menuService, context);
        InitializeAppStateRepositories(userRepo, eventsRepo, ticketsRepo);
    }
    
    /// <summary>
    /// The main application loop. It continuously runs until the ApplicationState.Running flag is set to false.
    /// In each iteration, it displays the current menu and executes the user's chosen action.
    /// </summary>
    public void Run()
    {
        while (_applicationState!.Running)
        {
            _applicationState.MenuService!.DisplayContent();
            
            var option = _applicationState.MenuService!.ChooseOption();
            option.ExecuteAction();
        }
    }
}