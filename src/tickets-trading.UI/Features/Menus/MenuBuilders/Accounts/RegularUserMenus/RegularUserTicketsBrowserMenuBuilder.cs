using tickets_trading.Domain;
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

        if (!user.OwnedTickets.Any())
        {
            items.Add(CreateNonSelectableItem("You have not bought any tickets yet"));
        }
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.RegularUserMainMenuBuilder?.Value;
        } ));
        items.Add(CreateItem("h", "Help", _helpService.Execute));
    }
}