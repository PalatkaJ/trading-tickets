using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserBrowseEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    private readonly RegularUserEventSubMenuBuilder _eventSubMenuBuilder = new(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        var allEvents = ApplicationState.EventsRepository!.GetAllEventsWithDependencies();

        bool eventsAvailable = false;
        foreach (var e in allEvents)
        {
            if (!e.TicketIsAvailable()) continue;
            
            items.Add(CreateItem($"{e.Title}", () =>
            {
                var menuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
                menuBuilder!.Event = e;
                ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
            }));

            eventsAvailable = true;
        }

        if (!eventsAvailable)
        {
            items.Add(CreateNonSelectableItem("There are no available events, please come back later"));
        }
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder?.Value;
        } ));
        items.Add(CreateItem("Help", _helpService.Execute));
    }
}