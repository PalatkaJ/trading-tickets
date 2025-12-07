using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_shop.UI.Features.UIServices.Items.Events;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.AdminEvents;
    
    private readonly EventCreationService _eventCreationService = new(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Create Event", _eventCreationService.DisplayContent));
        items.Add(CreateItem(SiteNames.AdminEventsBrowser, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsBrowserMenuBuilder!.Value);
        }));
        items.Add(CreateNonSelectableItem());
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value);
        }));
    }
}