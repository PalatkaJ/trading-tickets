using tickets_shop.Application.ServiceHandlers;
using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;
using tickets_shop.UI.Core.Startup;
using tickets_shop.UI.Features.UIServices.UIServiceSpecializers;

namespace tickets_shop.UI.Features.UIServices.Tickets;

/// <summary>
/// A concrete UI service responsible for managing the ticket purchase workflow.
/// It guides the user through selecting the number of tickets, confirming the purchase,
/// and displaying the final result (success or specific failure reason).
/// </summary>
/// <param name="applicationState">The application's shared state container.</param>
public class TicketsPurchaseService(ApplicationState applicationState): UIService
{
    // The handler responsible for executing the core purchase transaction logic.
    private readonly TicketsPurchaseHandler _ticketsPurchaseHandler = new(applicationState.DbContext!);

    private Event? _e;
    
    /// <summary>
    /// Gets the subtitle for this screen, which is generally related to the event sub-menu.
    /// </summary>
    protected override string Subtitle => SiteNames.RegEventSub;

    /// <summary>
    /// Starts the purchase workflow for a specific event.
    /// </summary>
    /// <param name="e">The Event entity the user is attempting to buy tickets for.</param>
    public void Execute(Event e)
    {
        _e = e;
        DisplayContent();
    }
    
    /// <summary>
    /// Attempts to parse the number of tickets input by the user and sets the appropriate message service on success or failure.
    /// </summary>
    /// <param name="nrInString">The raw string input from the user.</param>
    /// <param name="res">A reference parameter that holds the parsed integer amount if successful.</param>
    /// <param name="msgService">The message service (confirmation or failure) to display next.</param>
    /// <returns>True if parsing and validation succeed; otherwise, false.</returns>
    private bool TryParseNumberOfTickets(string nrInString, ref int res, out MessageService msgService)
    {
        string additionalMsg = "as the number of tickets you would like to purchase";
        
        try
        {
            int parsed = int.Parse(nrInString);
            if (parsed < 0) throw new InvalidOperationException();
            res = parsed;
            msgService = new TicketsPurchaseConfirmationService();
            return true;
        }
        catch (Exception ex) when (ex is FormatException || ex is InvalidOperationException)
        {
            msgService = new TicketsPurchaseFailedService($"""
                                                           {ErrorMessages.NumberInvalidFormat} 
                                                           {additionalMsg}
                                                           """);
            return false;
        }
        catch (OverflowException)
        {
            msgService = new TicketsPurchaseFailedService($"""
                                                           {ErrorMessages.NumberOverflow}
                                                           {additionalMsg}
                                                           """);
            return false;
        }
    }

    /// <summary>
    /// Handles the subsequent steps after successful number parsing: user confirmation,
    /// executing the purchase handler, and updating the message service based on the transaction result.
    /// </summary>
    private void ProceedOnSuccess(ref MessageService msgService, int nrOfTickets)
    {
        var confirmation = GetInput("Do you really want to purchase these tickets? [y/n]: ");
        if (confirmation == "n") return;
        
        var purchaseSuccessful = _ticketsPurchaseHandler.Handle(_e!, nrOfTickets);
        
        switch (purchaseSuccessful)
        {
            case PurchaseResult.NotEnoughMoney:
                msgService = new TicketsPurchaseFailedService(ErrorMessages.NotEnoughMoney);
                break;
            case PurchaseResult.NoTicketsAvailable:
                msgService = new TicketsPurchaseFailedService(ErrorMessages.NotEnoughTickets);
                break;
            case PurchaseResult.Success:
                // msgService remains the default confirmation service
                break;
        }
    }
    
    /// <summary>
    /// Displays the main purchase prompt and orchestrates the transaction workflow.
    /// </summary>
    protected override void DisplayCore()
    {
        // Set the current user on the handler before transaction begins
        _ticketsPurchaseHandler.User = (RegularUser)applicationState.CurrentUser!;
        
        int nrOfTickets = 1;
        string nrInString = GetInput("How many tickets would you like to purchase?: ");
        
        bool success = TryParseNumberOfTickets(nrInString, ref nrOfTickets, out var msgService);

        if (success)
        {
            ProceedOnSuccess(ref msgService, nrOfTickets);
        }
        
        // Display the final confirmation or failure message
        msgService.DisplayContent();
    }
}