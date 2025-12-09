using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

public class RegularUserBrowseEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegBrowseEvents;
    
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    
    private bool TryCreateEventItem(Event e, List<MenuItem> items)
    {
        if (!e.TicketsAreAvailable(nrOfTickets: 1)) return false;
            
        items.Add(CreateItem($"{e.Title}", () =>
        {
            var menuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
            menuBuilder!.Event = e;
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder!.Value);
        }));
        
        return true;
    }

    private IQueryable<Event> LazyLoadAllEvents()
    {
        return ApplicationState.EventsRepository!.LazyGetAllEventsWithDependencies();
    } 
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        IQueryable<Event> allEvents = LazyLoadAllEvents();

        bool foundEvent = false;
        foreach (var e in allEvents!)
        {
            foundEvent = foundEvent || TryCreateEventItem(e, items);
        }

        if (!foundEvent)
        {
            items.Add(CreateNonSelectableItem("There are no available events, please come back later"));
        }
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder!.Value);
        } ));
        items.Add(CreateItem("h",SiteNames.Help, _helpService.Execute));
    }
}