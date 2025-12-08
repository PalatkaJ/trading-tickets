using Microsoft.EntityFrameworkCore;
using tickets_shop.UI.Features.Menus.MenuBuilders;
using tickets_shop.UI.Features.UIServices.Menu;
using tickets_shop.Application.Authentication;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Infrastructure.Authentication;

namespace tickets_shop.UI.Core.Startup;

public class ConsoleAppController
{
    private readonly ApplicationState? _applicationState;

    private void InitializeAppStateMenu(MenuService menuService, DbContext context)
    {
        _applicationState!.MenuBuilder = LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value;

        _applicationState.MenuService = menuService;
        _applicationState.MenuService.MenuBuilder = _applicationState.MenuBuilder;
        
        _applicationState.DbContext = context;
    }

    private void InitializeAppStateRepositories(IUserRepository userRepo, IEventsRepository eventsRepo, ITicketsRepository ticketsRepo)
    {
        _applicationState!.UserRepository = userRepo;
        _applicationState.EventsRepository = eventsRepo;
        _applicationState.TicketsRepository = ticketsRepo;
    }
    
    public ConsoleAppController(IAuthenticationModule authenticationModule, MenuService menuService,
        IUserRepository userRepo, IEventsRepository eventsRepo, ITicketsRepository ticketsRepo, DbContext context)
    {
        _applicationState = new();
        
        LazyMenuBuildersLibrary.Initialize(_applicationState, authenticationModule);
        InitializeAppStateMenu(menuService, context);
        
        InitializeAppStateRepositories(userRepo, eventsRepo, ticketsRepo);
    }
    
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