using tickets_trading.Domain;
using tickets_trading.Domain.Authentication;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserTicketsBrowserMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly ItemDetailService<Ticket> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Ticket> _helpService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        RegularUser user = (RegularUser)ApplicationState.CurrentUser!;
        
        foreach (var t in user.OwnedTickets)
        {
            items.Add(CreateItem($"{t.Event!.Title}", () => {
                _itemDetailService.Execute(t);
            }));
        }

        items.Add(CreateItem("Help", _helpService.Execute));
        
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserMainMenuBuilder?.Value;
        } ));
    }
}