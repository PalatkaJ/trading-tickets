using tickets_trading.Application.Authentication;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Authentication;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Authentication;

public class SignUpMenuBuilder(AuthenticationModule authModule, ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    private readonly SignUpUIService _signUpUiService = new(applicationState);
    private readonly AuthenticationHelpService _authHelpService = new();

    public Action<User>? OnUserFound;
    
    protected override void BuildMiddleCore(List<MenuItem> items)
    {
        _signUpUiService.OnUserFound = OnUserFound;
        items.Add(CreateItem("Sign Up as an Admin", ()=>
        {
            _signUpUiService.Execute(authModule.SignUp<Admin>);
        }));
        items.Add(CreateItem("Sign Up as a Regular User", () =>
        {
            _signUpUiService.Execute(authModule.SignUp<RegularUser>);
        }));
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value;
        }));
        items.Add(CreateItem("h", "Help", _authHelpService.Execute));
    }
}