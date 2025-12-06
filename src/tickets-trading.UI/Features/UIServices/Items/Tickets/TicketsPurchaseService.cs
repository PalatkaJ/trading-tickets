using System.Globalization;
using tickets_trading.Application.ServiceHandlers;
using tickets_trading.Domain;
using tickets_trading.UI.Core.Startup;
using tickets_trading.UI.Features.UIServices.Items.Events;
using tickets_trading.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_trading.UI.Features.UIServices.Items.Tickets;

public class TicketsPurchaseService(ApplicationState applicationState): UIService
{
    private readonly TicketsPurchaseHandler _ticketsPurchaseHandler = new(applicationState.DbContext!);

    private Event? _e;
    protected override string Subtitle => "tickets purchase";

    public void Execute(Event e)
    {
        _e = e;
        Execute();
    }
    
    protected override void DisplayCore()
    {
        _ticketsPurchaseHandler.User = (RegularUser)applicationState.CurrentUser!;

        MessageService msgService = new TicketsPurchaseConfirmationService();
        int nrOfTickets = 1;
        try
        {
            nrOfTickets = int.Parse(GetInput("How many tickets would you like to purchase (default is 1)?: "));
        }
        catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
        {
            msgService = new TicketsPurchaseFailedService("""
                                                          Please enter a valid decimal positive number 
                                                          as the number of tickets you would like to purchase
                                                          """);
        }
        catch (OverflowException)
        {
            msgService = new TicketsPurchaseFailedService("""
                                                          Value was either too large or too small
                                                          as the number of tickets you would like to purchase
                                                          """);
        }

        var confirmation = GetInput("Do you really want to purchase these tickets? [y/n]: ");
        if (confirmation == "n") return;
        
        var purchaseSuccessful = _ticketsPurchaseHandler.Handle(_e!, nrOfTickets);
        
        switch (purchaseSuccessful)
        {
            case PurchaseResult.NotEnoughMoney:
                msgService = new TicketsPurchaseFailedService("You don't have enough money in your account.\nPlease recharge money in account information tab.");
                break;
            case PurchaseResult.NoTicketsAvailable:
                msgService = new TicketsPurchaseFailedService("There are no tickets left for this event.");
                break;
        }
        
        msgService.Execute();
    }
}