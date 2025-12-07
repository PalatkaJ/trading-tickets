using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public class AuthenticationConfirmationUIService: MessageService
{
    protected override string Subtitle => "authentication successful";

    protected override string Msg => 
        """
        Authentication was successful, you are logged in now
        """;
}