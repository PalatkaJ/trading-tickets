using tickets_trading.Application.Authentication;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class LogInUIService(AuthenticationModule authenticationModule, Action<User> onUserFound): UIService, IAuthenticationUI
{
    protected override string Subtitle => "LOG IN";

    protected override void DisplayCore()
    { 
        var (username, password) = ((IAuthenticationUI)this).GetCredentials();
        onUserFound(authenticationModule.LogIn(username, password));
    }
}