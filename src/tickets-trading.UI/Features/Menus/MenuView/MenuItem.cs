namespace tickets_trading.UI.Features.Menus.MenuView;

//public sealed record MenuItem(string Id, string Title, Action ExecuteAction);

public record MenuItem(string Id, string Title, Action ExecuteAction)
{
    public override string ToString()
    {
        return $"{Id}. {Title}";
    }
}

// for being able to print stuff in the menu view (this enables to print an empty line by default)
// empty item is not selectable by user
public sealed record NonSelectableMenuItem(string Content = ""): MenuItem("", Content, () => { })
{
    public override string ToString()
    {
        return Content;
    }
}