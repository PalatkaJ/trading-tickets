using tickets_trading.Domain;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminEventsBrowserMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        Admin admin = (Admin)ApplicationState.CurrentUser!;
        
        foreach (var e in admin.OrganizedEvents)
        {
            items.Add(CreateItem($"{e.Title}", () => {
                _itemDetailService.Execute(e);
            }));
        }

        if (!admin.OrganizedEvents.Any())
        {
            items.Add(CreateNonSelectableItem("You have not created any events yet"));
        }
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AdminEventsMenuBuilder?.Value;
        } ));
        items.Add(CreateItem("Help", _helpService.Execute));
    }
}