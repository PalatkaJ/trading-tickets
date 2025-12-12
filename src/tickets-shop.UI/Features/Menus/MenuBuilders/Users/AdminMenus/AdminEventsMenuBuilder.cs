using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Events;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.AdminMenus;

/// <summary>
/// The concrete menu builder for the Events Management screen available to Admin users.
/// It provides access to Event creation and event browsing features.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class AdminEventsMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.AdminEvents;
    
    // An instance of the service dedicated to the event creation workflow.
    private readonly EventCreationService _eventCreationService = new(applicationState);
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        // Option to initiate the Event Creation Service workflow.
        items.Add(CreateItem("Create Event", _eventCreationService.Execute));
        
        // Option to navigate to the event browser submenu.
        items.Add(CreateItem(SiteNames.AdminEventsBrowser, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsBrowserMenuBuilder!.Value);
        }));

        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the main menu.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value);
        }));
    }
}