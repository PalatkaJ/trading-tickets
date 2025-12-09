using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

public class RegularUserMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.Main;
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem(SiteNames.RegTicketsShop, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder!.Value);
        }));
        items.Add(CreateItem(SiteNames.RegTicketsBrowse, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserTicketsBrowserMenuBuilder!.Value);
        }));
        
        items.Add(CreateItem(SiteNames.AccountInfo, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserAccountInformationMenuBuilder!.Value);
        }));
        items.Add(CreateNonSelectableItem());
    }
}