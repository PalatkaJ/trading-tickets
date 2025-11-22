using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Common;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Items.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.AdminMenus;

public class AdminEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly EventCreationService _eventCreationService = new EventCreationService(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Create Event", _eventCreationService.Execute));
        items.Add(CreateItem("Browse Created Events", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AdminEventsBrowserMenuBuilder?.Value;
        }));
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AdminMainMenuBuilder?.Value;
        } ));
    }
}