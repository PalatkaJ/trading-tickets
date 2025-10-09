using tickets_trading.Application.Authentication;
using tickets_trading.Application.Common;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.Views;

namespace tickets_trading.UI.Features.Authentication;

public class LogInUiService(AuthenticationModule authenticationModule, Action<User> onUserFound): ConsoleViewBase, IAuthenticationUi, IService
{
    public void Execute() => DisplayContent();
    
    protected override void DisplayBody()
    { 
        var (username, password) = ((IAuthenticationUi)this).GetCredentials();
        onUserFound(authenticationModule.LogIn(username, password));
    }
}