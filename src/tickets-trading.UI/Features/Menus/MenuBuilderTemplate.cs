using tickets_trading.UI.Core.Views.OptionsView;

namespace tickets_trading.UI.Features.Menus;

public abstract class MenuBuilderTemplate: IMenuBuilder
{
    protected MenuItem CreateItem(string title, Action action)
    {
        return new($"{GetType().Name}.{title.Replace(" ", "")}", $"{title}", action);
    }

    public void BuildMiddle(List<MenuItem> items)
    {
        BuildMiddleCore(items);
        items.Add(CreateItem($"Exit", () => Environment.Exit(0)));   
    }

    protected abstract void BuildMiddleCore(List<MenuItem> items);
}