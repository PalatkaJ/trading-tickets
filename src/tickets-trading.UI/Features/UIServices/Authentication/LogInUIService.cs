using tickets_trading.Application.Authentication;
using tickets_trading.Domain;
using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class LogInUIService: AuthenticationUIService
{
    protected override string Subtitle => "log in";

    public LogInUIService(AuthenticationModule authenticationModule)
    {
        AuthenticationMethod = authenticationModule.LogIn;
    }
}