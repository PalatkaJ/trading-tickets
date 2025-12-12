using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

/// <summary>
/// A concrete help service that provides an overview of the application's user roles (Admin and Regular User)
/// and explains the function of the initial authentication options (Sign Up and Log In).
/// </summary>
public class AuthenticationHelpService: HelpService
{
    /// <summary>
    /// Gets the detailed help message explaining the user types and authentication actions.
    /// </summary>
    protected override string Msg => 
        """
        Simple tickets shop application, you can sign/ log into as:
            1. ADMIN
                - you can put tickets into market but NOT buy them
            2. REGULAR USER
                - you can buy tickets to events created by admins
                 (you will not be able to create events)
        Sign Up - use if you have not already created an account (regular user/ admin)
        Log In - use if you have already created an account (regular user/ admin).
        """;
}