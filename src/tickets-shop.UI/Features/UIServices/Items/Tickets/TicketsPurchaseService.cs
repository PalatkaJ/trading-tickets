using tickets_shop.Application.ServiceHandlers;
using tickets_shop.Domain;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseService(ApplicationState applicationState): UIService
{
    private readonly TicketsPurchaseHandler _ticketsPurchaseHandler = new(applicationState.DbContext!);

    private Event? _e;
    protected override string Subtitle => SiteNames.RegEventSub;

    public void DisplayContent(Event e)
    {
        _e = e;
        DisplayContent();
    }
    
    private bool TryParseNumberOfTickets(string nrInString, ref int res, out MessageService msgService)
    {
        string additionalMsg = "as the number of tickets you would like to purchase";
        
        try
        {
            int parsed = int.Parse(nrInString);
            res = parsed;
            msgService = new TicketsPurchaseConfirmationService();
            return true;
        }
        catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
        {
            msgService = new TicketsPurchaseFailedService($"""
                                                           {AppMessages.NumberInvalidFormat} 
                                                           {additionalMsg}
                                                           """);
            return false;
        }
        catch (OverflowException)
        {
            msgService = new TicketsPurchaseFailedService($"""
                                                           {AppMessages.NumberOverflow}
                                                           {additionalMsg}
                                                           """);
            return false;
        }
    }
    
    protected override void DisplayCore()
    {
        _ticketsPurchaseHandler.User = (RegularUser)applicationState.CurrentUser!;
        
        int nrOfTickets = 1;
        string nrInString = GetInput("How many tickets would you like to purchase (default is 1)?: ");
        
        bool success = TryParseNumberOfTickets(nrInString, ref nrOfTickets, out var msgService);

        if (success)
        {
            var confirmation = GetInput("Do you really want to purchase these tickets? [y/n]: ");
            if (confirmation == "n") return;
            
            var purchaseSuccessful = _ticketsPurchaseHandler.Handle(_e!, nrOfTickets);
        
            switch (purchaseSuccessful)
            {
                case PurchaseResult.NotEnoughMoney:
                    msgService = new TicketsPurchaseFailedService(AppMessages.NotEnoughMoney);
                    break;
                case PurchaseResult.NoTicketsAvailable:
                    msgService = new TicketsPurchaseFailedService(AppMessages.NotEnoughTickets);
                    break;
            }
        }
        
        msgService.DisplayContent();
    }
}