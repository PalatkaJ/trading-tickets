using Microsoft.EntityFrameworkCore;
using tickets_trading.Application.Authentication;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.UI.Features.Menus.MenuBuilders;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Core.Startup;

public class ConsoleAppController
{
    private readonly ApplicationState? _applicationState;

    private readonly IMenuView? _menuView;
    
    public ConsoleAppController(AuthenticationModule authenticationModule, IMenuView menuView,
        IUserRepository userRepo, IEventsRepository eventsRepo, ITicketsRepository ticketsRepo, DbContext context)
    {
        _applicationState = new();
        LazyMenuBuildersLibrary.Initialize(_applicationState, authenticationModule);
        
        _menuView = menuView;
        _applicationState.MenuBuilder = LazyMenuBuildersLibrary.AuthenticationMenuBuilder?.Value;

        _applicationState.DbContext = context;
        _applicationState.UserRepository = userRepo;
        _applicationState.EventsRepository = eventsRepo;
        _applicationState.TicketsRepository = ticketsRepo;
    }
    
    public void Run()
    {
        while (_applicationState!.Running)
        {
            SetMenuViewOptions();
            
            _menuView!.DisplayContent();
            
            var option = _menuView!.ChooseOption();
            option.ExecuteAction();
        }
    }

    private void SetMenuViewOptions()
    {
        var options = _applicationState!.MenuBuilder!.BuildMenu();
        _menuView!.Options = options;
    }
}