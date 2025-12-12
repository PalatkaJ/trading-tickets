using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

/// <summary>
/// A concrete message service used to display a standardized confirmation message
/// to the user after a successful login or sign-up attempt.
/// </summary>
public class AuthenticationConfirmationService: MessageService
{
    protected override string Subtitle => "authentication successful";
    
    protected override string Msg => 
        """
        Authentication was successful, you are logged in now.
        """;
}