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
        
        foreach (var e in allEvents)
        {
            items.Add(CreateItem($"{e.Title}", () =>
            {
                var menuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
                menuBuilder!.Event = e;
                ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserEventSubMenuBuilder?.Value;
            }));
        }
        
        items.Add(CreateItem("Help", _helpService.Execute));
        
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder?.Value;
        } ));
    }
}