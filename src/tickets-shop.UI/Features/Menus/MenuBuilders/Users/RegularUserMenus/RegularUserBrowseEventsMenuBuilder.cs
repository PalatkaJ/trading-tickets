using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

/// <summary>
/// The concrete menu builder for the Events Browser screen for Regular Users.
/// It displays a list of all events that currently have tickets available for sale.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class RegularUserBrowseEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegBrowseEvents;
    
    // Service for displaying help instructions for event browsing.
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    
    /// <summary>
    /// Attempts to create a selectable MenuItem for a given Event if tickets are available.
    /// If created, the action sets the current event and navigates to the event submenu.
    /// </summary>
    /// <param name="e">The Event entity to potentially list.</param>
    /// <param name="items">The list to which the MenuItem is added.</param>
    /// <returns>True if the item was created (tickets are available); otherwise, false.</returns>
    private bool TryCreateEventItem(Event e, List<MenuItem> items)
    {
        // Check if at least one ticket is available
        if (!e.TicketsAreAvailable(nrOfTickets: 1)) return false;
            
        items.Add(CreateItem($"{e.Title}", () =>
        {
            var menuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
            menuBuilder!.Event = e;
            
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder!.Value);
        }));
        
        return true;
    }

    /// <summary>
    /// Retrieves all Event entities from the repository using a lazy-loading IQueryable pattern.
    /// </summary>
    /// <returns>An IQueryable collection of all events with necessary dependencies.</returns>
    private IQueryable<Event> LazyLoadAllEvents()
    {
        return ApplicationState.EventsRepository!.LazyGetAllEventsWithDependencies();
    } 
    
    /// <summary>
    /// Builds the menu by iterating through all available events and listing those with tickets.
    /// </summary>
    /// <param name="items">The list to which custom MenuItems are added.</param>
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        IQueryable<Event> allEvents = LazyLoadAllEvents();

        bool foundEvent = false;
        // The query is executed here as the list is iterated.
        foreach (var e in allEvents!)
        {
            foundEvent = foundEvent || TryCreateEventItem(e, items);
        }

        if (!foundEvent)
        {
            items.Add(CreateNonSelectableItem("There are no available events, please come back later"));
        }
        
        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the Tickets Shop menu.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder!.Value);
        } ));

        // Option to show specific help instructions for browsing events.
        items.Add(CreateItem("h",SiteNames.Help, _helpService.Execute));
    }
}