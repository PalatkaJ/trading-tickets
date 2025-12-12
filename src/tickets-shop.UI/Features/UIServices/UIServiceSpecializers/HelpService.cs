using tickets_shop.Domain;

namespace tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

/// <summary>
/// Provides an abstract base class for all Help-specific informational screens.
/// It sets the standard subtitle and inherits the core message display and
/// "Enter to continue" functionality from its parent classes.
/// </summary>
public abstract class HelpService: MessageService
{
    /// <summary>
    /// Gets the fixed subtitle for all help screens.
    /// </summary>
    protected override string Subtitle => SiteNames.Help;
}