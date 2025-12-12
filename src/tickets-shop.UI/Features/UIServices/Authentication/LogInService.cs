using tickets_shop.Application.Authentication;

namespace tickets_shop.UI.Features.UIServices.Authentication;

/// <summary>
/// A concrete UI service that facilitates the user login process.
/// It sets the specific authentication function (IAuthenticationModule.LogIn)
/// for the base AuthenticationService to execute.
/// </summary>
public class LogInService: AuthenticationService
{
    protected override string Subtitle => "log in";

    /// <summary>
    /// Initializes the service by setting the base class's AuthenticationMethod delegate
    /// to the specific LogIn method provided by the IAuthenticationModule.
    /// </summary>
    /// <param name="authenticationModule">The application's core authentication service.</param>
    public LogInService(IAuthenticationModule authenticationModule)
    {
        AuthenticationMethod = authenticationModule.LogIn;
    }
}