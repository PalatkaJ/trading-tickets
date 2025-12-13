using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Authentication;
using tickets_shop.Application.Authentication;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Authentication;

/// <summary>
/// The concrete menu builder for the user registration (Sign Up) screen.
/// It allows the unauthenticated user to choose their desired role (Admin or Regular User)
/// before executing the registration workflow.
/// </summary>
/// <param name="authModule">The application's core authentication service containing the SignUp logic.</param>
/// <param name="applicationState">The application's shared state container.</param>
public class SignUpMenuBuilder(IAuthenticationModule authModule, ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.SignUp;
    
    // Services for handling the registration workflow and displaying help.
    private readonly SignUpService _signUpService = new();
    private readonly AuthenticationHelpService _authHelpService = new();

    /// <summary>
    /// An action delegate that is invoked by the SignUpService upon successful registration,
    /// typically used to update the ApplicationState with the new user.
    /// </summary>
    public Action<User>? OnUserFound;
    
    protected override void BuildMiddle(List<MenuItem> items)
    {
        _signUpService.OnUserFound = OnUserFound;
        
        // 1. Option to sign up as an Admin
        items.Add(CreateItem("Sign Up as an Admin", ()=>
        {
            _signUpService.Execute(authModule.SignUp<Admin>); 
        }));

        // 2. Option to sign up as a Regular User
        items.Add(CreateItem("Sign Up as a Regular User", () =>
        {
            _signUpService.Execute(authModule.SignUp<RegularUser>);
        }));
        
        items.Add(CreateNonSelectableItem()); // Separator

        // 3. Option to return to the main authentication menu.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value);
        }));

        // 5. Option to display help information.
        items.Add(CreateItem("h", SiteNames.Help, _authHelpService.Execute));
    }
}