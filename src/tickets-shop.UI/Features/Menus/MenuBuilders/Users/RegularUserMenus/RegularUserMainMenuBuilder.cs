using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

/// <summary>
/// The concrete menu builder for the main screen displayed to a logged-in Regular User.
/// It provides navigation options for purchasing tickets, browsing owned tickets, and account management.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class RegularUserMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.Main;

    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        // Option to navigate to the tickets shop/purchase menu
        items.Add(CreateItem(SiteNames.RegTicketsShop, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder!.Value);
        }));

        // Option to navigate to the browser for viewing already owned tickets
        items.Add(CreateItem(SiteNames.RegTicketsBrowse, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserTicketsBrowserMenuBuilder!.Value);
        }));
        
        // Option to navigate to the account information screen
        items.Add(CreateItem(SiteNames.AccountInfo, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserAccountInformationMenuBuilder!.Value);
        }));

        items.Add(CreateNonSelectableItem()); // Separator
    }
}