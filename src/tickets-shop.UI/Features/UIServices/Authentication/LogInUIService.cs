using tickets_shop.Application.Authentication;
using tickets_shop.Domain;
using tickets_shop.Infrastructure.Authentication;
using tickets_shop.UI.Core.InputOutput;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public class LogInUIService: AuthenticationUIService
{
    protected override string Subtitle => "log in";

    public LogInUIService(IAuthenticationModule authenticationModule)
    {
        AuthenticationMethod = authenticationModule.LogIn;
    }
}