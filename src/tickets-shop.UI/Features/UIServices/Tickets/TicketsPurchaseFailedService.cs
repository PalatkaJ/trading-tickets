using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Tickets;

/// <summary>
/// A concrete message service used to display a standardized failure message
/// to the user after a ticket purchase attempt fails.
/// </summary>
/// <param name="additional">The specific reason for the failure.</param>
public class TicketsPurchaseFailedService(string additional): MessageService
{
    protected override string Subtitle => "not enough tickets";
    
    protected override string Msg => 
        $"""
         Ticket(s) purchase failed: {additional}
         """;
}