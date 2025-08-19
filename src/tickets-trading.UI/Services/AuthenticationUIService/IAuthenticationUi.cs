using tickets_trading.Application;
using tickets_trading.Application.Services;
using tickets_trading.UI.View;
using tickets_trading.Domain;


namespace tickets_trading.UI.Services.AuthenticationUIService;

public interface IAuthenticationUi: IView
{
    public (string, string) GetCredentials()
    {
        var username = GetInput("Username: ");
        var password = GetInput("Password: ");
        return (username!, password!);
    }
}