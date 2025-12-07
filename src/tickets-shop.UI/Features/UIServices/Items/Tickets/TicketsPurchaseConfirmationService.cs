using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseConfirmationService: MessageService
{
    protected override string Subtitle => "purchase successful";

    protected override string Msg => 
        """
        Ticket(s) was/were purchased successfully, you can check them out by browsing all tickets
        that you have already bought
        """;
}