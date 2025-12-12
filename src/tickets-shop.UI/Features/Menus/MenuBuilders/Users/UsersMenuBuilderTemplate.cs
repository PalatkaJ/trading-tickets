using tickets_shop.Domain;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;

namespace tickets_shop.UI.Features.Menus.MenuBuilders.Users;

/// <summary>
/// Provides an abstract base class for all menus displayed after a user has successfully authenticated.
/// It defines common actions (Log Out, Back to Main Menu) and some utilities.
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public abstract class UsersMenuBuilderTemplate(ApplicationState applicationState): MenuBuilderTemplate(applicationState)
{
    /// <summary>
    /// Utility method to explicitly load the necessary navigation properties (dependencies)
    /// of the currently logged-in User entity (e.g., tickets for a RegularUser, events for an Admin).
    /// </summary>
    protected void EagerLoadDependencies()
    {
        ApplicationState.UserRepository!.EagerLoadUsersDependencies(ApplicationState.CurrentUser!);
    }
    
    /// <summary>
    /// Defines the structure of the menu body, appending the standard authenticated options
    /// (Back to Main Menu and Log Out) after the specific middle content is built.
    /// </summary>
    /// <param name="items">The list to which custom and standard MenuItems are added.</param>
    protected override void BuildMiddle(List<MenuItem> items)
    {
        // 1. Add specific content defined by the derived class
        BuildMiddleSpecific(items);

        // 2. Add 'Back to Main Menu' option (links to Admin or Regular User main menu)
        items.Add(CreateItem("m", SiteNames.Main, () =>
        {
            ChangeMenuTo(ApplicationState.CurrentUser is Admin
                ? LazyMenuBuildersLibrary.AdminMainMenuBuilder!.Value
                : LazyMenuBuildersLibrary.RegularUserMainMenuBuilder!.Value);
        }));

        // 3. Add 'Log Out' option
        items.Add(CreateItem("l","Log Out", () =>
        {
            ApplicationState.CurrentUser = null;
            ChangeMenuTo(LazyMenuBuildersLibrary.AuthenticationMenuBuilder!.Value);
        }));
    }

    /// <summary>
    /// Abstract method implemented by derived classes to add all role-specific menu options.
    /// </summary>
    /// <param name="items">The list to which custom MenuItems should be added.</param>
    protected abstract void BuildMiddleSpecific(List<MenuItem> items);
}