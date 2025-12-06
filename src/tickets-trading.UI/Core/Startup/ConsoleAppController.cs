using Microsoft.EntityFrameworkCore;
using tickets_trading.Application.Authentication;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.UI.Features.Menus.MenuBuilders;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Menu;

namespace tickets_trading.UI.Core.Startup;

public class ConsoleAppController
{
    private readonly ApplicationState? _applicationState;
    
    public ConsoleAppController(AuthenticationModule authenticationModule, MenuService menuService,
        IUserRepository userRepo, IEventsRepository eventsRepo, ITicketsRepository ticketsRepo, DbContext context)
    {
        _applicationState = new();
        LazyMenuBuildersLibrary.Initialize(_applicationState, authenticationModule);
        _applicationState.MenuBuilder = LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value;

        _applicationState.MenuService = menuService;
        _applicationState.MenuService.MenuBuilder = _applicationState.MenuBuilder;
        
        _applicationState.DbContext = context;
        
        _applicationState.UserRepository = userRepo;
        _applicationState.EventsRepository = eventsRepo;
        _applicationState.TicketsRepository = ticketsRepo;
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