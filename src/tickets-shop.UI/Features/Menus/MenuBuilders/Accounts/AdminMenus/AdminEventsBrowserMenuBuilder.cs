using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_shop.UI.Features.UIServices.Items;
using tickets_shop.UI.Features.UIServices.Items.Events;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminEventsBrowserMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.AdminEventsBrowser;
    
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        Admin admin = (Admin)ApplicationState.CurrentUser!;
        
        foreach (var e in admin.OrganizedEvents)
        {
            items.Add(CreateItem($"{e.Title}", () => {
                _itemDetailService.DisplayContent(e);
            }));
        }

        if (!admin.OrganizedEvents.Any())
        {
            items.Add(CreateNonSelectableItem("You have not created any events yet"));
        }
        
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsMenuBuilder!.Value);
        } ));
        items.Add(CreateItem("h", "Help", _helpService.DisplayContent));
    }
}