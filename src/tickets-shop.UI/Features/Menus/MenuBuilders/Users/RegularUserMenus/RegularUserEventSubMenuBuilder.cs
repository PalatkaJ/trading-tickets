using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Tickets;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

/// <summary>
/// The concrete menu builder for the submenu displayed when a Regular User selects a specific event.
/// It enables actions relevant to a single event, such as viewing details and purchasing tickets.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class RegularUserEventSubMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegEventSub;
    
    // Services for displaying item details and initiating ticket purchase.
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly TicketsPurchaseService _ticketsPurchaseService = new(applicationState);
    
    /// <summary>
    /// The specific Event entity currently being acted upon. This must be set by the calling menu builder
    /// before this menu is executed.
    /// </summary>
    public Event? Event { get; set; }
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        // Option to display the detailed information of the specific event.
        items.Add(CreateItem($"Show Detail About {Event!.Title}", () => {
            _itemDetailService.Execute(Event!);
        }));

        // Option to initiate the ticket purchase workflow for the specific event.
        items.Add(CreateItem($"Purchase Tickets", () =>
        {
            _ticketsPurchaseService.Execute(Event);
        }));

        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the event browsing screen.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBrowseEventsMenuBuilder!.Value);
        }));
    }
}