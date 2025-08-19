using tickets_trading.Application;
using tickets_trading.Application.Services;
using tickets_trading.UI.View;
using tickets_trading.Domain;

namespace tickets_trading.UI.Services.AuthenticationUIService;

public class LogInUiService(AuthenticationModule authenticationModule, Action<User> onUserFound): SimpleConsoleView, IAuthenticationUi, IService
{
    public void Execute() => DisplayContent();
    
    protected override void DisplayBody()
    { 
        var (username, password) = ((IAuthenticationUi)this).GetCredentials();
        onUserFound(authenticationModule.LogIn(username, password));
    }
}