using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class AuthenticationFailedUIService(string additional): MessageService
{
    protected override string Subtitle => "authentication failed";

    protected override string Msg => 
        $"""
        Authentication failed: {additional}
        """;
}