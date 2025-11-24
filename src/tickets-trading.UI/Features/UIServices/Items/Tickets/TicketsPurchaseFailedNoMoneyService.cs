using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseFailedNoMoneyService: MessageService
{
    protected override string Subtitle => "not enough money";
    
    protected override string Msg => 
        """
        Ticket was not purchased, please add money in account information tab
        """;
}