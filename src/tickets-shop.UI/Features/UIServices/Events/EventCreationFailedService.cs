using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Events;

/// <summary>
/// A concrete message service used to display a standardized failure message
/// to the user after an attempt to create a new Event entity fails.
/// </summary>
/// <param name="additional">The specific reason for the failure.</param>
public class EventCreationFailedService(string additional): MessageService
{
    protected override string Subtitle => "event creation failed";
    
    protected override string Msg => 
        $"""
         Event creation failed: {additional}
         """;
}