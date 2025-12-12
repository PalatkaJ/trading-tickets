using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Users;

/// <summary>
/// A concrete message service used to display a standardized failure message
/// to the user after an attempt to add money to their account fails.
/// </summary>
/// <param name="additional">The specific reason for the failure.</param>
public class MoneyAddingFailedService(string additional): MessageService
{
    protected override string Subtitle => "adding money failed";
    
    protected override string Msg => 
        $"""
         Adding money failed: {additional}
         """;
}