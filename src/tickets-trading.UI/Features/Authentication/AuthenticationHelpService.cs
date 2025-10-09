using tickets_trading.UI.Features.Help;

namespace tickets_trading.UI.Features.Authentication;

public class AuthenticationHelpService: HelpService
{
    protected override string Msg => 
        """
        Simple tickets trading application, you can sign/ log into as:
            1. admin
                you can put tickets into market but NOT buy them or trade them with other users
            2. normal user
                you can buy tickets from admins and trade them with other normal users (NOT admins)
        Sign Up - use if you have not already created an account (user/ admin)
        Log In - use if you have already created an account (user/ admin)
        """;
}