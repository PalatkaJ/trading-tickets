using tickets_shop.Domain;
using tickets_shop.UI.Core.InputOutput;

namespace tickets_shop.UI.Features.UIServices;

/// <summary>
/// Provides a base class for all application-specific UI services (screens/pages).
/// It extends the base console template by enforcing and formatting a standardized
/// subtitle area below the main application header.
/// </summary>
public abstract class UIService: ConsoleIOTemplate
{
    // Generates a decorative line used to visually separate the subtitle from the body content.
    private readonly string _subtitleLine = new(AppConstants.SubTitleBoarder, AppConstants.WindowWidth);
    
    /// <summary>
    /// Abstract property that must be implemented by derived classes to provide the unique
    /// title for the current screen or view (e.g., "Login", "Event Details").
    /// </summary>
    protected abstract string Subtitle { get; }

    /// <summary>
    /// The default execution method for the service, which triggers the full content display pipeline.
    /// This method is mostly for getting rid of side effects problems if we always call DisplayContent()
    /// (because some UI services also do some action using a handler)
    /// </summary>
    public void Execute() => DisplayContent();
    
    /// <summary>
    /// Draws the standardized subtitle block, centering the subtitle text and adding a border line.
    /// </summary>
    private void DisplaySubtitle()
    {
        ShowMessage($"""
                     {GetTransformedTitle(Subtitle)}
                     {_subtitleLine}

                     """);   
    }
    
    /// <summary>
    /// Overrides the base template method to structure the body content: Subtitle, Core Content, then spacing.
    /// </summary>
    protected override void DisplayBody()
    {
        DisplaySubtitle();
        DisplayCore();
        ShowMessage("\n");
    }

    /// <summary>
    /// Abstract method that must be implemented by derived classes to display the unique,
    /// interactive content of the service (e.g., forms, lists, tables).
    /// </summary>
    protected abstract void DisplayCore();
}