using tickets_trading.Application;
using tickets_trading.Domain;
using tickets_trading.UI.View;
using tickets_trading.UI.View.Menu;
using tickets_trading.UI.View.Menu.MenuBuilders;

namespace tickets_trading.UI.Controller;

public class ConsoleAppController
{
    private readonly AuthenticationModule _authenticationModule;
    private User? _currentUser;
    private bool _running = true;
    private IMenuBuilder _menuBuilder;

    private readonly AdminMenuBuilder _adminMenuBuilder = new AdminMenuBuilder();
    private readonly UserMenuBuilder _userMenuBuilder = new UserMenuBuilder();
    private readonly AuthenticationMenuBuilder _authenticationMenuBuilder;
    private readonly IMenuView _menuView;

    public ConsoleAppController(AuthenticationModule authenticationModule, IMenuView menuView)
    {
        _menuView = menuView;
        _authenticationModule = authenticationModule;
        _authenticationMenuBuilder = new AuthenticationMenuBuilder(authenticationModule, user => { _currentUser = user; });
    }
    
    public void Run()
    {
        while (_running)
        {
            SetCurrentMenuBuilder();
            var options = _menuBuilder.BuildMenu();
            _menuView.Options = options;
            _menuView.DisplayContent();
            var option = _menuView.ChooseOption();
            option.ExecuteAction();
        }
    }

    private void SetCurrentMenuBuilder()
    {
        if (_currentUser is null) { _menuBuilder = _authenticationMenuBuilder; return; }
        _menuBuilder = _currentUser is Admin ? _adminMenuBuilder : _userMenuBuilder;
    }
}