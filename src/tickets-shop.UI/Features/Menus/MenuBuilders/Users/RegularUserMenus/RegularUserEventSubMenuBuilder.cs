using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Tickets;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.RegularUserMenus;

public class RegularUserEventSubMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.RegEventSub;
    
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