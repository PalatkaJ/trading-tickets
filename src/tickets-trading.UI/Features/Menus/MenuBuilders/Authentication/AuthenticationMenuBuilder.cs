using tickets_trading.Application.Authentication;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Authentication;
using tickets_trading.UI.Features.Help;
using tickets_trading.UI.Features.Menus.MenuView;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;

public class AuthenticationMenuBuilder: MenuBuilderTemplate
{
    private readonly SignUpUiService? _signUpUiService;
    private readonly LogInUiService? _logInUiService;

    private readonly AuthenticationHelpService? _authHelpService;

    public AuthenticationMenuBuilder(AuthenticationModule authModule, ApplicationState applicationState): base(applicationState)
    {
        Action<User> onUserFound = user =>
        {
            ApplicationState.CurrentUser = user;
            ApplicationState.MenuBuilder = user is Admin ? 
                LazyMenuBuildersLibrary.AdminMenuBuilder?.Value
                : LazyMenuBuildersLibrary.UserMenuBuilder?.Value;
        };

        _signUpUiService = new(authModule, onUserFound);
        _logInUiService = new(authModule, onUserFound);
        _authHelpService = new();
    }
    
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Sign Up", _signUpUiService!.Execute));
        items.Add(CreateItem("Log In", _logInUiService!.Execute));
        items.Add(CreateItem("Help", _authHelpService!.Execute));
    }
}