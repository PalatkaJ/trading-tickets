using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.AdminMenus;

/// <summary>
/// The concrete menu builder for the screen that allows an Admin user to browse
/// and select all the Event entities they have organized.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class AdminEventsBrowserMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.AdminEventsBrowser;
    
    // Services for displaying item details and help instructions.
    private readonly ItemDetailService<Event> _itemDetailService = new();
    private readonly BrowseItemsHelpService<Event> _helpService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        Domain.Users.Admin admin = (Domain.Users.Admin)ApplicationState.CurrentUser!;
        
        // Ensure the list of events is loaded before accessing the collection.
        EagerLoadDependencies();
        
        // Create a menu item for each organized event, using the event's title as the ID/Title.
        foreach (var e in admin.OrganizedEvents)
        {
            items.Add(CreateItem($"{e.Title}", () => {
                _itemDetailService.Execute(e);
            }));
        }

        // Display a message if no events have been created yet.
        if (!admin.OrganizedEvents.Any())
        {
            items.Add(CreateNonSelectableItem("You have not created any events yet"));
        }
        
        items.Add(CreateNonSelectableItem()); // Separator
        
        // Option to navigate back to the previous menu.
        items.Add(CreateItem("b", "Back", () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsMenuBuilder!.Value);
        } ));
        
        items.Add(CreateItem("h", "Help", _helpService.Execute));
    }
}