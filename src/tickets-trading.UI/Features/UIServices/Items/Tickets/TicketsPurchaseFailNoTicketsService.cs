using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseFailNoTicketsService: MessageService
{
    protected override string Subtitle => "not enough tickets";
    
    protected override string Msg => 
        """
        Ticket was not purchased, sadly there are no tickets available for 
        this event anymore
        """;
}