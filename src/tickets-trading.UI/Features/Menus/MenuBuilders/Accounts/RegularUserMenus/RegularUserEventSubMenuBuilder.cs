using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserEventSubMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly ItemDetailService<Event> _itemDetailService = new();
    public Event? Event { get; set; }
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem($"Show Detail About {Event!.Title}", () => {
            _itemDetailService.Execute(Event!);
        }));
        items.Add(CreateItem($"Purchase For {Event!.Price} {Event!.Currency}", () => {}));
        
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserBrowseEventsMenuBuilder?.Value;
        }));
    }
}