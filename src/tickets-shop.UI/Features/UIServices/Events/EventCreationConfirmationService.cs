using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Events;

/// <summary>
/// A concrete message service used to display a standardized confirmation message
/// to the user after a new Event entity has been successfully created and persisted.
/// </summary>
public class EventCreationConfirmationService: MessageService
{
    protected override string Subtitle => "creation successful";
    
    protected override string Msg => 
        """
        Event was created successfully, you can check it out by browsing all events
        that you have already created.
        """;
}