using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.Menus.MenuView;
using tickets_trading.UI.Features.UIServices.Events;

namespace tickets_trading.UI.Features.Menus.MenuBuilders.Accounts.Admin;

public class AdminEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    private readonly EventCreationService _eventCreationService = new EventCreationService(applicationState);
    private readonly EventsBrowsingService _eventsBrowsingService  = new EventsBrowsingService(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        items.Add(CreateItem("Create Event", _eventCreationService.Execute));
        items.Add(CreateItem("Browse All Events", _eventsBrowsingService.Execute));
        //maybe back to main menu? we will see
        items.Add(CreateItem("Back", () =>
        {
            ApplicationState.MenuBuilder = LazyMenuBuildersLibrary.AdminMainMenuBuilder?.Value;
        } ));
    }
}