using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseFailedService(string additional): MessageService
{
    protected override string Subtitle => "not enough tickets";
    
    protected override string Msg => 
        $"""
        Ticket purchase failed: {additional}
        """;
}