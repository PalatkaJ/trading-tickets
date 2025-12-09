using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users;

public abstract class UsersMenuBuilderTemplate(ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    protected void EagerLoadDependencies()
    {
        ApplicationState.UserRepository!.EagerLoadUsersDependencies(ApplicationState.CurrentUser!);
    }
    
    protected override void BuildMiddle(List<MenuItem> items)
    {
        BuildMiddleSpecific(items);
        items.Add(CreateItem("m", SiteNames.Main, () =>
        {
            ChangeMenuTo(ApplicationState.CurrentUser is Admin
                ? LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));
        items.Add(CreateItem("l","Log Out", () =>
        {
            ApplicationState.CurrentUser = null;
            ChangeMenuTo(LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value);
        }));
    }

    protected abstract void BuildMiddleSpecific(List<MenuItem> items);
}