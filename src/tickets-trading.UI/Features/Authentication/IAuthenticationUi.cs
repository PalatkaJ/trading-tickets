using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.Authentication;

public interface IAuthenticationUi: IView
{
    public (string, string) GetCredentials()
    {
        var username = GetInput("Username: ");
        var password = GetInput("Password: ");
        return (username!, password!);
    }
}