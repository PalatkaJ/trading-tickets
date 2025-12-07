using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public class AuthenticationFailedUIService(string additional): MessageService
{
    protected override string Subtitle => "authentication failed";

    protected override string Msg => 
        $"""
        Authentication failed: {additional}
        """;
}