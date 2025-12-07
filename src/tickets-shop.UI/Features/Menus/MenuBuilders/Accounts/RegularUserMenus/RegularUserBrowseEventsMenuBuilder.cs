using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Items.Events;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserBrowseEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegBrowseEvents;
    
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    private readonly RegularUserEventSubMenuBuilder _eventSubMenuBuilder = new(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        var allEvents = ApplicationState.EventsRepository!.GetAllEventsWithDependencies();

        bool eventsAvailable = false;
        foreach (var e in allEvents)
        {
            if (!e.TicketsAreAvailable(nrOfTickets: 1)) continue;
            
            items.Add(CreateItem($"{e.Title}", () =>
            {
                var menuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
                menuBuilder!.Event = e;
                ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder!.Value);
            }));

            eventsAvailable = true;
        }

        if (!eventsAvailable)
        {
            items.Add(CreateNonSelectableItem("There are no available events, please come back later"));
        }
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder!.Value);
        } ));
        items.Add(CreateItem("h",SiteNames.Help, _helpService.DisplayContent));
    }
}