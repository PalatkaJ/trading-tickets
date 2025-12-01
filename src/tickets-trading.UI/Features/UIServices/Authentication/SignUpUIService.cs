using tickets_trading.Application.Authentication;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Core.View;
using tickets_trading.UI.Features.Menus.MenuBuilders;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class SignUpUIService(ApplicationState applicationState): AuthenticationUIService
{
    protected override string Subtitle => "sign up";
}