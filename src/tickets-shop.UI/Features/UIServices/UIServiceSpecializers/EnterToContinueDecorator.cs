using tickets_shop.UI.Core.InputOutput;

namespace tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

public abstract class EnterToContinueDecorator: UIService
{
    protected override void DisplayFooter()
    {
        base.DisplayFooter();
        GetInput("Press Enter to continue... ");
    }
}