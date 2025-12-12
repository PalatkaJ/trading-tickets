namespace tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

/// <summary>
/// An abstract decorator class that overrides the standard footer behavior of a UIService.
/// It forces the user to press the Enter key before the application continues to the next screen.
/// </summary>
public abstract class EnterToContinueDecorator: UIService
{
    protected override void DisplayFooter()
    {
        base.DisplayFooter();
        GetInput("Press Enter to continue... ");
    }
}