using tickets_shop.Domain;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;
using tickets_shop.UI.Core.InputOutput;

namespace tickets_shop.UI.Features.UIServices.Authentication;

public abstract class AuthenticationUIService : UIService
{
    protected Func<string, string, User>? AuthenticationMethod;

    public Action<User>? OnUserFound;

    public void DisplayContent(Func<string, string, User> f)
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
    
    protected override void DisplayCore()
    { 
        var (username, password) = GetCredentials();
        MessageService authResult = new AuthenticationConfirmationUIService(); 
        try
        {
            var user = AuthenticationMethod!(username, password);
            OnUserFound!(user);
        }
        catch (Exception ex) when (ex is InvalidOperationException || ex is UnauthorizedAccessException)
        {
            authResult = new AuthenticationFailedUIService(ex.Message);
        }
        authResult.DisplayContent();
    }
}