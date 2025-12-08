using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public class AuthenticationHelpService: HelpService
{
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