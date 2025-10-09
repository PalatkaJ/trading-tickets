using tickets_trading.Application.Authentication;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Features.Authentication;
using tickets_trading.UI.Core.Views.OptionsView;

namespace tickets_trading.UI.Features.Menus.Authentication;

public class AuthenticationMenuBuilder(AuthenticationModule authModule, Action<User> onUserFound) : MenuBuilderTemplate
{
    private readonly SignUpUiService _signUpUiService = new(authModule, onUserFound);
    private readonly LogInUiService _logInUiService = new(authModule, onUserFound);
    
    private readonly AuthenticationHelpService _authHelpService = new();

    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem("Sign Up", _signUpUiService.Execute));
        items.Add(CreateItem("Log In", _logInUiService.Execute));
        items.Add(CreateItem("Help", _authHelpService.Execute));
    }
}