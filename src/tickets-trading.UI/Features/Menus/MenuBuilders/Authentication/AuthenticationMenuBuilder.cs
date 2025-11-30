using tickets_trading.Application.Authentication;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Authentication;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;

public class AuthenticationMenuBuilder: MenuBuilderTemplate
{
    private readonly SignUpUIService? _signUpUiService;
    private readonly LogInUIService? _logInUiService;

    private readonly AuthenticationHelpService _authHelpService = new();

    public AuthenticationMenuBuilder(AuthenticationModule authModule, ApplicationState applicationState): base(applicationState)
    {
        Action<User> onUserFound = user =>
        {
            ApplicationState.CurrentUser = user;
            ApplicationState.MenuBuilder = user is Admin ? 
                LazyMenuBuildersLibrary.AdminMainMenuBuilder?.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder?.Value;
        };

        _signUpUiService = new(authModule, onUserFound);
        _logInUiService = new(authModule, onUserFound);
    }
    
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Sign Up", _signUpUiService!.Execute));
        items.Add(CreateItem("Log In", _logInUiService!.Execute));
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("Help", _authHelpService!.Execute));
    }
}