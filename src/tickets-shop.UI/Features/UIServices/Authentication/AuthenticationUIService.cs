using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;
using tickets_shop.UI.Core.InputOutput;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public abstract class AuthenticationUIService : UIService
{
    protected Func<string, string, User>? AuthenticationMethod;

    public Action<User>? OnUserFound;

    public void Execute(Func<string, string, User> f)
    {
        AuthenticationMethod = f;
        DisplayContent();
    }
    
    private (string, string) GetCredentials()
    {
        var username = GetInput("Username: ");
        var password = GetInput("Password: ");
        return (username!, password!);
    }

    private MessageService TryProcessUser(string username, string passwd)
    {
        try
        {
            var user = AuthenticationMethod!(username, passwd);
            OnUserFound!(user);
            return new AuthenticationConfirmationUIService();
        }
        catch (Exception ex) when (ex is InvalidOperationException || ex is UnauthorizedAccessException)
        {
            return new AuthenticationFailedUIService(ex.Message);
        }
    }
    
    protected override void DisplayCore()
    { 
        var (username, password) = GetCredentials();
        var authResult = TryProcessUser(username, password);
        
        authResult.DisplayContent();
    }
}