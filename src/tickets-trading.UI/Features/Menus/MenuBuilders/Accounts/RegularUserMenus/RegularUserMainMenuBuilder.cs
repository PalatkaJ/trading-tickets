using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly ItemDetailService<Ticket> _itemDetailService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Buy Tickets", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder?.Value;
        }));
        items.Add(CreateItem("My Tickets", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserTicketsBrowserMenuBuilder?.Value;
        }));
        
        // TODO maybe add to UserTemplate bcs Admin has this too
        items.Add(CreateItem("Account Information", () => { }));
        items.Add(CreateNonSelectableItem());
    }
}