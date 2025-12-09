using tickets_shop.UI.Core.Startup;
using tickets_shop.Domain;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

public class RegularUserTicketsShopMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegTicketsShop;
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem(SiteNames.RegBrowseEvents, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBrowseEventsMenuBuilder!.Value);
        }));
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b","Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));
    }
}