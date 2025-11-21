using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices;

public abstract class UIService: ConsoleViewBase
{
    private readonly string _subtitleLine = new('─', HeadlineLength);
    protected abstract string Subtitle { get; }
    
    public void Execute()
    {
        DisplayContent();
    }

    private void DisplaySubtitle() => ShowMessage($"{GetTransformedTitle(Subtitle)}\n{_subtitleLine}\n");
    
    protected override void DisplayBody()
    {
        DisplaySubtitle();
        DisplayCore();
        ShowMessage("\n");
    }

    protected abstract void DisplayCore();
}