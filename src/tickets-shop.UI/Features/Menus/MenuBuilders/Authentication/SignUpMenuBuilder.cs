using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Authentication;
using tickets_shop.Application.Authentication;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Authentication;

public class SignUpMenuBuilder(AuthenticationModule authModule, ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.SignUp;
    
    private readonly SignUpUIService _signUpUiService = new();
    private readonly AuthenticationHelpService _authHelpService = new();

    public Action<User>? OnUserFound;
    
    protected override void BuildMiddle(List<MenuItem> items)
    {
        _signUpUiService.OnUserFound = OnUserFound;
        items.Add(CreateItem("Sign Up as an Admin", ()=>
        {
            _signUpUiService.DisplayContent(authModule.SignUp<Admin>);
        }));
        items.Add(CreateItem("Sign Up as a Regular User", () =>
        {
            _signUpUiService.DisplayContent(authModule.SignUp<RegularUser>);
        }));
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value);
        }));
        items.Add(CreateItem("h", "Help", _authHelpService.DisplayContent));
    }
}