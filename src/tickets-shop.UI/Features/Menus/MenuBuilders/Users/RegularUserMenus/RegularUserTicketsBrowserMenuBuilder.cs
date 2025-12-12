using tickets_shop.Domain;
using tickets_shop.Domain.Tickets;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

/// <summary>
/// The concrete menu builder for the screen that allows a Regular User to browse
/// and select all the Ticket entities they have previously purchased.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class RegularUserTicketsBrowserMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegTicketsBrowse;
    
    // Services for displaying item details and help instructions for tickets.
    private readonly ItemDetailService<Ticket> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Ticket> _helpService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        Domain.Users.RegularUser user = (Domain.Users.RegularUser)ApplicationState.CurrentUser!;
        
        // Ensure the OwnedTickets collection and related Event details are loaded.
        EagerLoadDependencies();
        
        // Create a menu item for each owned ticket.
        foreach (var t in user.OwnedTickets)
        {
            items.Add(CreateItem($"{t.Event!.Title} (Seat-{t.Seat})", () => {
                _itemDetailService.Execute(t);
            }));
        }

        // Display a message if the user has no tickets.
        if (!user.OwnedTickets.Any())
        {
            items.Add(CreateNonSelectableItem("You have not bought any tickets yet"));
        }
        
        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the Regular User Main Menu.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        } ));

        // Option to show specific help instructions for browsing items.
        items.Add(CreateItem("h", SiteNames.Help, _helpService.Execute));
    }
}