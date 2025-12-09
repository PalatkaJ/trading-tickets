using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Authentication;
using tickets_shop.Application.Authentication;
using tickets_shop.Domain.Users;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Authentication;

public class AuthenticationMenuBuilder: MenuBuilderTemplate
{
    public override string Title => SiteNames.Auth;
    
    private readonly LogInUIService _logInUiService;

    private Action<User> OnUserFound;

    public AuthenticationMenuBuilder(IAuthenticationModule authModule, ApplicationState applicationState): base(applicationState)
    {
        OnUserFound = user =>
        {
            ApplicationState.CurrentUser = user;
            ChangeMenuTo(user is Admin ? 
                LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        };
        
        _logInUiService = new(authModule)
        {
            OnUserFound = OnUserFound
        };
    }
    
    protected override void BuildMiddle(List<MenuItem> items)
    {
        items.Add(CreateItem(SiteNames.SignUp, () =>
        {
            LazyMenuBuildersLibrary.SignUpMenuBuilder!.Value.OnUserFound = OnUserFound;
            ChangeMenuTo(LazyMenuBuildersLibrary.SignUpMenuBuilder.Value);
        }));
        items.Add(CreateItem("Log In", () =>
        {
            _logInUiService.Execute();
        }));
        items.Add(CreateNonSelectableItem());
    }
}