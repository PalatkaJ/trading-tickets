using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Authentication;
using tickets_shop.Application.Authentication;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Authentication;

public class SignUpMenuBuilder(IAuthenticationModule authModule, ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.SignUp;
    
    private readonly SignUpService _signUpService = new();
    private readonly AuthenticationHelpService _authHelpService = new();

    public Action<User>? OnUserFound;
    
    protected override void BuildMiddle(List<MenuItem> items)
    {
        _signUpService.OnUserFound = OnUserFound;
        items.Add(CreateItem("Sign Up as an Admin", ()=>
        {
            _signUpService.Execute(authModule.SignUp<Admin>);
        }));
        items.Add(CreateItem("Sign Up as a Regular User", () =>
        {
            _signUpService.Execute(authModule.SignUp<RegularUser>);
        }));
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value);
        }));
        items.Add(CreateItem("h", "Help", _authHelpService.Execute));
    }
}