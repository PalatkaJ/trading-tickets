using tickets_shop.Domain.Users;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Authentication;

/// <summary>
/// Provides an abstract base class for all authentication-related UI workflows (e.g., Log In, Sign Up).
/// It handles the standardized process of gathering credentials, executing the core authentication method,
/// and displaying the appropriate success or failure message.
/// </summary>
public abstract class AuthenticationService : UIService
{
    /// <summary>
    /// The core authentication logic delegate (Func) to be executed by the service.
    /// This is typically provided by the AuthenticationModule service.
    /// </summary>
    protected Func<string, string, User>? AuthenticationMethod;

    /// <summary>
    /// An action delegate (Action) that is invoked when authentication is successful,
    /// usually used to update the ApplicationState with the logged-in User entity.
    /// </summary>
    public Action<User>? OnUserFound;

    /// <summary>
    /// Starts the authentication workflow, setting the specific logic method to be used.
    /// </summary>
    /// <param name="f">The core authentication function (e.g., LogIn or SignUp).</param>
    public void Execute(Func<string, string, User> f)
    {
        AuthenticationMethod = f;
        DisplayContent();
    }
    
    /// <summary>
    /// Prompts the user for a username (visible input) and a password (invisible input).
    /// </summary>
    /// <returns>A tuple containing the username and password strings.</returns>
    private (string, string) GetCredentials()
    {
        var username = GetInput("Username: ");
        // Uses the invisible input utility for security
        var password = GetInputInvisible("Password: ");
        return (username!, password!);
    }

    /// <summary>
    /// Executes the AuthenticationMethod delegate and handles the outcome.
    /// </summary>
    /// <param name="username">The entered username.</param>
    /// <param name="passwd">The entered password.</param>
    /// <returns>A concrete MessageService instance (Confirmation or Failure) based on the result.</returns>
    private MessageService TryProcessUser(string username, string passwd)
    {
        try
        {
            var user = AuthenticationMethod!(username, passwd);
            OnUserFound!(user); 
            
            return new AuthenticationConfirmationService();
        }
        // Catches expected authentication errors (e.g., bad credentials, user exists/not found)
        catch (Exception ex) when (ex is InvalidOperationException || ex is UnauthorizedAccessException)
        {
            return new AuthenticationFailedService(ex.Message);
        }
    }
    
    /// <summary>
    /// Overrides the core display logic to orchestrate the credential gathering and authentication process.
    /// </summary>
    protected override void DisplayCore()
    { 
        var (username, password) = GetCredentials();
        var authResult = TryProcessUser(username, password);
        
        // Display the result message (success or failure)
        authResult.DisplayContent();
    }
}