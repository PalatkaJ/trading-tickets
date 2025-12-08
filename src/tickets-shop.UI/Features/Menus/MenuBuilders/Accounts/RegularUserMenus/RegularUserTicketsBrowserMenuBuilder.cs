using tickets_shop.Domain;
using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Items.Events;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.RegularUserMenus;

public class RegularUserTicketsBrowserMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegTicketsBrowse;
    
    private readonly ItemDetailService<Ticket> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Ticket> _helpService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        RegularUser user = (RegularUser)ApplicationState.CurrentUser!;
        EagerLoadDependencies();
        
        foreach (var t in user.OwnedTickets)
        {
            items.Add(CreateItem($"{t.Event!.Title} ({t.Seat})", () => {
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
            ChangeMenuTo(LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        } ));
        items.Add(CreateItem("h", SiteNames.Help, _helpService.Execute));
    }
}