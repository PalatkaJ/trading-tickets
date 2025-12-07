using tickets_shop.UI.Core.Startup;
using tickets_shop.Application.Authentication;
using tickets_shop.Domain;
using tickets_shop.UI.Core.InputOutput;
using tickets_shop.UI.Features.Menus.MenuBuilders;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public class SignUpUIService: AuthenticationUIService
{
    protected override string Subtitle => "sign up";
}