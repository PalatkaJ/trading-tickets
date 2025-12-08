namespace tickets_shop.UI.Features.Menus;

public record MenuItem(string Id, string Title, Action ExecuteAction)
{
    public override string ToString()
    {
        return $"{Id} - {Title}";
    }
}

public sealed record NonSelectableMenuItem(string Content = ""): MenuItem("", Content, () => { })
{
    public override string ToString()
    {
        return Content;
    }
}