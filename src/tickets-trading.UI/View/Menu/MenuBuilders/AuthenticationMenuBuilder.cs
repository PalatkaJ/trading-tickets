using tickets_trading.Application;
using tickets_trading.UI.Services.HelpServices;
using tickets_trading.Domain;
using tickets_trading.UI.Services.AuthenticationUIService;

namespace tickets_trading.UI.View.Menu.MenuBuilders;

public class AuthenticationMenuBuilder(AuthenticationModule authModule, Action<User> onUserFound) : MenuBuilderTemplate
{
    private readonly SignUpUiService _signUpUiService = new(authModule, onUserFound);
    private readonly LogInUiService _logInUiService = new(authModule, onUserFound);

    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Sign Up", _signUpUiService.Execute));
        items.Add(CreateItem("Log In", _logInUiService.Execute));
        items.Add(CreateItem("Help", new AuthenticationHelpService().Execute));
        base.BuildMiddleCore(items);
    }
}