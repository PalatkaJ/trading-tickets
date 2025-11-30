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
    private readonly TicketsPurchaseConfirmationService _ticketsPurchaseConfirmationService = new();
    private readonly TicketsPurchaseFailNoTicketsService _ticketsPurchaseFailNoTicketsService = new();
    private readonly TicketsPurchaseFailedNoMoneyService _ticketsPurchaseFailNoMoneyService = new();

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
        
        var confirmation = GetInput("Are you sure you want to purchase this ticket? [y/n]: ");
        if (confirmation == "n") return;
        
        var purchaseSuccessful = _ticketsPurchaseHandler.Handle(_e!);

        MessageService msgService = new TicketsPurchaseConfirmationService();
        
        switch (purchaseSuccessful)
        {
            case PurchaseResult.NotEnoughMoney:
                msgService = new TicketsPurchaseFailedNoMoneyService();
                break;
            case PurchaseResult.NoTicketsAvailable:
                msgService = new TicketsPurchaseFailNoTicketsService();
                break;
        }
        
        msgService.Execute();
    }
}