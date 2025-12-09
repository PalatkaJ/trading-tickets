using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Tickets;

public class TicketsPurchaseFailedService(string additional): MessageService
{
    protected override string Subtitle => "not enough tickets";
    
    protected override string Msg => 
        $"""
        Ticket(s) purchase failed: {additional}
        """;
}