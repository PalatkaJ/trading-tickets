namespace tickets_shop.UI.Features.Menus;

/// <summary>
/// Represents a selectable item within a menu.
/// </summary>
/// <param name="Id">The unique identifier (e.g., "1", "q") the user inputs to select this item.</param>
/// <param name="Title">The descriptive text displayed to the user for this option.</param>
/// <param name="ExecuteAction">The Action delegate (code block) that runs when this item is selected.</param>
public record MenuItem(string Id, string Title, Action ExecuteAction)
{
    /// <summary>
    /// Overrides the default ToString to display the menu item in the standard format: "Id - Title".
    /// </summary>
    /// <returns>The formatted menu item string.</returns>
    public override string ToString()
    {
        return $"{Id} - {Title}";
    }
}

/// <summary>
/// Represents a non-selectable item within a menu (e.g., an empty line).
/// Note that it is selectable by pressing only enter, but it is a no-op so we
/// don't really care.
/// </summary>
/// <param name="Content">The static text content to display. Id is always empty, and the action is a no-op.</param>
public sealed record NonSelectableMenuItem(string Content = ""): MenuItem("", Content, () => { })
{
    /// <summary>
    /// Overrides the base ToString to display only the raw content, without the ID or separator.
    /// </summary>
    /// <returns>The raw content string.</returns>
    public override string ToString()
    {
        return Content;
    }
}