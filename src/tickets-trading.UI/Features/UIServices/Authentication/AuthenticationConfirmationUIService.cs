using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class AuthenticationConfirmationUIService: MessageService
{
    protected override string Subtitle => "authentication successful";

    protected override string Msg => 
        """
        Authentication was successful, you are logged in now.
        """;
}