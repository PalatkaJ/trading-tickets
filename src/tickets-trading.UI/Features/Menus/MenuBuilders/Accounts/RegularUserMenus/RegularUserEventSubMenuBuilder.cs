using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;
using tickets_trading.UI.Features.UIServices.Items.Tickets;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserEventSubMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => "tickets purchase";
    
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly TicketsPurchaseService _ticketsPurchaseService = new(applicationState);
    
    public Event? Event { get; set; }
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem($"Show Detail About {Event!.Title}", () => {
            _itemDetailService.Execute(Event!);
        }));
        items.Add(CreateItem($"Purchase Tickets", () =>
        {
            _ticketsPurchaseService.Execute(Event);
        }));
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBrowseEventsMenuBuilder!.Value);
        }));
    }
}