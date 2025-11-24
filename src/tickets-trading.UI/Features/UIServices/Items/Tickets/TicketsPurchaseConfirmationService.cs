using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseConfirmationService: MessageService
{
    protected override string Subtitle => "purchase successful";

    protected override string Msg => 
        """
        Ticket was purchased successfully, you can check it out by browsing all tickets
        that you have already bought
        """;
}