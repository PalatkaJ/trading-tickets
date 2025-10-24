using tickets_trading.Application.Authentication;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Features.Menus;
using tickets_trading.UI.Features.Menus.MenuBuilders;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.User;
using tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Core.Startup;

public class ConsoleAppController
{
    private readonly AuthenticationModule _authenticationModule;
    
    private bool _running = true;
    private User? _currentUser;
    private IMenuBuilder? _menuBuilder;
    private readonly IMenuView _menuView;
    
    private readonly AdminMenuBuilder _adminMenuBuilder = new();
    private readonly UserMenuBuilder _userMenuBuilder = new();
    private readonly AuthenticationMenuBuilder _authenticationMenuBuilder;
    

    public ConsoleAppController(AuthenticationModule authenticationModule, IMenuView menuView)
    {
        _authenticationModule = authenticationModule;
        _menuView = menuView;
        _authenticationMenuBuilder = new AuthenticationMenuBuilder(authenticationModule, user => { _currentUser = user; });
    }
    
    public void Run()
    {
        while (_running)
        {
            SetCurrentMenuBuilder();
            SetMenuViewOptions();
            
            _menuView.DisplayContent();
            
            var option = _menuView.ChooseOption();
            option.ExecuteAction();
        }
    }
    
    // the menus for user and admin differ
    private void SetCurrentMenuBuilder()
    {
        if (_currentUser is null) { 
            _menuBuilder = _authenticationMenuBuilder; 
            return; 
        }
        
        _menuBuilder = _currentUser is Admin ? _adminMenuBuilder : _userMenuBuilder;
    }

    private void SetMenuViewOptions()
    {
        var options = _menuBuilder!.BuildMenu();
        _menuView.Options = options;
    }
}