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
        
        var confirmation = GetInput("Do you really want to purchase this ticket? [y/n]: ");
        if (confirmation == "n") return;
        
        var purchaseSuccessful = _ticketsPurchaseHandler.Handle(_e!);

        MessageService msgService = new TicketsPurchaseConfirmationService();
        
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