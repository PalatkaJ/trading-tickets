using tickets_shop.UI.Core.Startup;

namespace tickets_shop.UI.Features.Menus.MenuBuilders;

/// <summary>
/// Provides an abstract template for constructing standardized application menus.
/// It enforces a common structure, manages item IDs, and provides methods for menu navigation.
/// </summary>
/// <param name="applicationState">The application's shared state container, necessary for menu transitions and actions.</param>
public abstract class MenuBuilderTemplate(ApplicationState applicationState)
{
    /// <summary>
    /// Abstract property that must be implemented by derived classes to provide the descriptive title of the menu.
    /// This title is used by the MenuService for the screen's subtitle.
    /// </summary>
    public abstract string Title { get; }
    
    protected readonly ApplicationState ApplicationState = applicationState;
    
    // Counter used to generate sequential, numerical IDs for menu items.
    private int _currentFreeItemId = 1; 
    
    /// <summary>
    /// Creates a standard, selectable MenuItem with the next available sequential integer ID.
    /// </summary>
    /// <param name="title">The display text for the menu option.</param>
    /// <param name="action">The code to execute when the option is selected.</param>
    /// <returns>A new MenuItem instance.</returns>
    protected MenuItem CreateItem(string title, Action action)
    {
        return new(_currentFreeItemId++.ToString(), title, action);
    }

    /// <summary>
    /// Creates a standard, selectable MenuItem with a custom, non-sequential string ID (e.g., "q", "h").
    /// </summary>
    /// <param name="id">The custom ID (input key).</param>
    /// <param name="title">The display text for the menu option.</param>
    /// <param name="action">The code to execute when the option is selected.</param>
    /// <returns>A new MenuItem instance.</returns>
    protected MenuItem CreateItem(string id, string title, Action action)
    {
        return new(id, title, action);
    }

    /// <summary>
    /// Creates a NonSelectableMenuItem used for display purposes (e.g. empty line).
    /// </summary>
    /// <param name="content">The text content to display.</param>
    /// <returns>A new NonSelectableMenuItem instance.</returns>
    protected NonSelectableMenuItem CreateNonSelectableItem(string content = "") => new(content);

    /// <summary>
    /// Utility method to change the currently active menu for the application, updating both the
    /// ApplicationState and the MenuService references.
    /// </summary>
    /// <param name="targetMenu">The new MenuBuilderTemplate to switch to.</param>
    protected void ChangeMenuTo(MenuBuilderTemplate targetMenu)
    {
        ApplicationState.MenuBuilder = targetMenu;
        ApplicationState.MenuService!.MenuBuilder = targetMenu;
    }

    /// <summary>
    /// The final method that orchestrates the menu construction. It calls the abstract BuildMiddle
    /// and appends the standard 'Exit' option.
    /// </summary>
    /// <returns>A complete list of MenuItem objects ready for display.</returns>
    public List<MenuItem> BuildMenu()
    {
        var items = new List<MenuItem>();
        BuildMiddle(items); // Content provided by derived classes
        items.Add(CreateItem("e", "Exit", () =>
        {
            ApplicationState.Running = false;
        }));
        
        // Reset the counter for the next time the menu is built
        _currentFreeItemId = 1;
        return items;
    }

    /// <summary>
    /// Abstract method implemented by derived classes to add all custom, application-specific
    /// menu options before the Exit option.
    /// </summary>
    /// <param name="items">The list to which custom MenuItems should be added.</param>
    protected abstract void BuildMiddle(List<MenuItem> items);
}