using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

public abstract class EnterToContinueDecorator: UIService
{
    protected override void DisplayFooter()
    {
        base.DisplayFooter();
        GetInput("Press Enter to continue... ");
    }
}