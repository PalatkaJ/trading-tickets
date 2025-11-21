using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Authentication;

public class AuthenticationHelpService: HelpService
{
    protected override string Msg => 
        """
        Simple tickets trading application, you can sign/ log into as:
            1. admin
                you can put tickets into market but NOT buy them or trade them with regular users
            2. regular user
                you can buy tickets from admins and trade them with other regular users (NOT admins)
        Sign Up - use if you have not already created an account (regular user/ admin)
        Log In - use if you have already created an account (regular user/ admin)
        """;
}