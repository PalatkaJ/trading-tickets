using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => "main menu";
    
    private readonly ItemDetailService<Ticket> _itemDetailService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Tickets Shop", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserBuyTicketsMenuBuilder!.Value);
        }));
        items.Add(CreateItem("My Tickets", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserTicketsBrowserMenuBuilder!.Value);
        }));
        
        items.Add(CreateItem("Account Information", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserAccountInformationMenuBuilder!.Value);
        }));
        items.Add(CreateNonSelectableItem());
    }
}