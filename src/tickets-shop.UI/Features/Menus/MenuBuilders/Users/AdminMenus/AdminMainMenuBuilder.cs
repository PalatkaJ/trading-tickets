using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.Items;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users.AdminMenus;

/// <summary>
/// The concrete menu builder for the main screen displayed to a logged-in Admin user.
/// It provides navigation options for event management and viewing personal account details.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class AdminMainMenuBuilder(ApplicationState applicationState): UsersMenuBuilderTemplate(applicationState)
{
    public override string Title => SiteNames.Main;
    
    // An instance of the generic detail service configured to display User (Admin) details.
    private readonly ItemDetailService<User> _adminDetailService = new();
    
    protected override void BuildMiddleSpecific(List<MenuItem> items)
    {
        // Option to navigate to the events management submenu
        items.Add(CreateItem(SiteNames.AdminEvents, () =>
        {
            ChangeMenuTo(LazyMenuBuildersLibrary.AdminEventsMenuBuilder!.Value);
        }));
        
        // Option to view the admin's own account details
        items.Add(CreateItem(SiteNames.AccountInfo, () =>
        {
            _adminDetailService.Execute(ApplicationState.CurrentUser!);
        }));
        items.Add(CreateNonSelectableItem()); // Separator
    }
}