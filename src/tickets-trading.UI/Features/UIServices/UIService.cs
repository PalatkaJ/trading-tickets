using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices;

public abstract class UIService: ConsoleViewBase
{
    protected abstract string Subtitle { get; }
    
    public void Execute()
    {
        DisplayContent();
    }

    protected override void DisplayBody()
    {
        ShowMessage(Subtitle + "\n");
        DisplayCore();
    }

    protected abstract void DisplayCore();
}