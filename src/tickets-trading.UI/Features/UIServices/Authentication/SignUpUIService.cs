using tickets_trading.Application.Authentication;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class SignUpUIService(AuthenticationModule authenticationModule, Action<User> onUserFound): UIService, IAuthenticationUI
{
    protected override string Subtitle => "SIGN UP";

    protected override void DisplayCore()
    { 
        var option = GetInput("Sign Up as an admin? [y/n]: ");
        var (username, password) = ((IAuthenticationUI)this).GetCredentials();

        switch (option)
        {
            case "y":
            {
                onUserFound(authenticationModule.SignUp<Admin>(username, password));
                break;
            }
            case "n":
            { 
                onUserFound(authenticationModule.SignUp<RegularUser>(username, password));
                break;
            }
        }
    }
}