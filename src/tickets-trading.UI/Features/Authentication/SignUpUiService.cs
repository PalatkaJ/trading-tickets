using tickets_trading.Application.Authentication;
using tickets_trading.Application.Common;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.Authentication;

public class SignUpUiService(AuthenticationModule authenticationModule, Action<User> onUserFound): ConsoleViewBase, IAuthenticationUi, IService
{
    public void Execute() => DisplayContent();
    
    protected override void DisplayBody()
    { 
        var option = GetInput("Sign Up as an admin? [y/n]: ");
        var (username, password) = ((IAuthenticationUi)this).GetCredentials();

        switch (option)
        {
            case "y":
            {
                onUserFound(authenticationModule.SignUp<Admin>(username, password));
                break;
            }
            case "n":
            { 
                onUserFound(authenticationModule.SignUp<User>(username, password));
                break;
            }
        }
    }
}