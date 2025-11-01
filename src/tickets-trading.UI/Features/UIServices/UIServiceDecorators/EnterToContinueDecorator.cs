using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices.UIServiceDecorators;

public abstract class EnterToContinueDecorator: UIService
{
    protected override void DisplayFooter()
    {
        base.DisplayFooter();
        GetInput("Press Enter to return to the previous page...");
    }
}