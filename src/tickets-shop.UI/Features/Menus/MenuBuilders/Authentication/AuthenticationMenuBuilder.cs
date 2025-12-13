using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Authentication;
using tickets_shop.Application.Authentication;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Authentication;

/// <summary>
/// The concrete menu builder for the application's initial, unauthenticated screen.
/// It provides options to log in or sign up and defines the logic for transitioning
/// the user to the appropriate main menu upon successful authentication.
/// </summary>
public class AuthenticationMenuBuilder: MenuBuilderTemplate
{
    public override string Title => SiteNames.Auth;
    
    private readonly LogInService _logInService;

    // The action delegate executed when any authentication service finds a user.
    private Action<User> _onUserFound;

    /// <summary>
    /// Initializes the builder, setting up the core onUserFound logic and the LogInService.
    /// </summary>
    /// <param name="authModule">The core authentication logic provider.</param>
    /// <param name="applicationState">The application's shared state container.</param>
    public AuthenticationMenuBuilder(IAuthenticationModule authModule, ApplicationState applicationState): base(applicationState)
    {
        _onUserFound = user =>
        {
            ApplicationState.CurrentUser = user;
            
            ChangeMenuTo(user is Admin ? 
                LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        };
        
        _logInService = new(authModule)
        {
            OnUserFound = _onUserFound
        };
    }
    
    protected override void BuildMiddle(List<MenuItem> items)
    {
        // Option to navigate to the Sign Up menu.
        items.Add(CreateItem(SiteNames.SignUp, () =>
        {
            LazyMenuBuildersLibrary.SignUpMenuBuilder!.Value.OnUserFound = _onUserFound;
            ChangeMenuTo(LazyMenuBuildersLibrary.SignUpMenuBuilder.Value);
        }));

        // Option to initiate the Log In workflow.
        items.Add(CreateItem("Log In", () =>
        {
            _logInService.Execute();
        }));

        items.Add(CreateNonSelectableItem());
    }
}