using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

/// <summary>
/// A concrete message service used to display a standardized failure message
/// to the user after an attempt to log in or sign up fails.
/// </summary>
/// <param name="additional">The specific reason for the authentication failure.</param>
public class AuthenticationFailedService(string additional): MessageService
{
    protected override string Subtitle => "authentication failed";
    
    protected override string Msg => 
        $"""
         Authentication failed: {additional}
         """;
}