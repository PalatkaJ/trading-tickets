using tickets_trading.Application;
using tickets_trading.Application.Services;
using tickets_trading.UI.View;
using tickets_trading.Domain;

namespace tickets_trading.UI.Services.AuthenticationUIService;

public class SignUpUiService(AuthenticationModule authenticationModule, Action<User> onUserFound): SimpleConsoleView, IAuthenticationUi, IService
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