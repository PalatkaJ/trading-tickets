namespace tickets_trading.UI.View.Menu.MenuBuilders;

public abstract class MenuBuilderTemplate: IMenuBuilder
{
    protected MenuItem CreateItem(string title, Action action)
    {
        return new($"{GetType().Name}.{title.Replace(" ", "")}", $"{title}", action);
    }

    protected virtual void BuildMiddleCore(List<MenuItem> items)
    {
        items.Add(CreateItem($"Exit", () => Environment.Exit(0)));
    }

    public void BuildMiddle(List<MenuItem> items) => BuildMiddleCore(items);
    
}