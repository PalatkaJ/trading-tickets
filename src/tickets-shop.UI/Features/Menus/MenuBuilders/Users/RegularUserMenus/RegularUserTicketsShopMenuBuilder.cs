using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

/// <summary>
/// The concrete menu builder for the main entry point into the ticket shop for a Regular User.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class RegularUserTicketsShopMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegTicketsShop;
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        // Option to navigate to the detailed events browser where tickets can be purchased.
        items.Add(CreateItem(SiteNames.RegBrowseEvents, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBrowseEventsMenuBuilder!.Value);
        }));
        
        // here could be also added the option to trade tickets with other users

        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the Regular User Main Menu.
        items.Add(CreateItem("b","Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));
    }
}