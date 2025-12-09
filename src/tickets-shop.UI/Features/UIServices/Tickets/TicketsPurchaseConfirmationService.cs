using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Tickets;

public class TicketsPurchaseConfirmationService: MessageService
{
    protected override string Subtitle => "purchase successful";

    protected override string Msg => 
        """
        Ticket(s) purchased successfully, you can see that by browsing all tickets
        that you have already bought.
        """;
}