namespace tickets_shop.UI.Features.UIServices.Authentication;

/// <summary>
/// A concrete UI service that facilitates the user sign-up (registration) process.
/// It provides the specific subtitle for the sign-up screen, relying on the calling
/// code to set the IAuthenticationModule.SignUp method via the base class's Execute method.
/// </summary>
public class SignUpService: AuthenticationService
{
    protected override string Subtitle => "sign up";
}