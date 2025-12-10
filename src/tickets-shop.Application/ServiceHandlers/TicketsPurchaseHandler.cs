using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

/// <summary>
/// Represents the possible outcomes of a ticket purchase attempt.
/// </summary>
public enum PurchaseResult
{
    /// <summary>The purchase was completed successfully.</summary>
    Success,
    /// <summary>The event does not have the requested number of tickets available.</summary>
    NoTicketsAvailable,
    /// <summary>The user does not have enough money to complete the purchase.</summary>
    NotEnoughMoney
}

/// <summary>
/// A service handler responsible for validating and executing the purchase of tickets,
/// managing user balance updates, ticket ownership assignment, and database persistence.
/// </summary>
/// <param name="context">The Entity Framework Core DbContext used to finalize and commit the transaction.</param>
public class TicketsPurchaseHandler(DbContext context)
{
    /// <summary>
    /// The RegularUser performing the purchase. This must be set before calling the Handle method.
    /// </summary>
    public RegularUser? User;

    /// <summary>
    /// Checks the prerequisites for a valid purchase, including ticket availability and user funds.
    /// </summary>
    /// <param name="e">The Event from which tickets are being purchased.</param>
    /// <param name="nrOfTickets">The number of tickets requested.</param>
    /// <param name="totalPrice">The pre-calculated total cost of the tickets.</param>
    /// <param name="result">The specific reason for failure or success.</param>
    /// <returns>True if all checks pass; otherwise, false.</returns>
    private bool CheckPurchaseValid(Event e, int nrOfTickets, int totalPrice, out PurchaseResult result)
    {
        if (!e.TicketsAreAvailable(nrOfTickets))
        {
            result = PurchaseResult.NoTicketsAvailable;
            return false;
        }

        if (!User!.HasEnoughMoney(totalPrice))
        {
            result = PurchaseResult.NotEnoughMoney;
            return false;
        }

        result = PurchaseResult.Success;
        return true;
    }

    /// <summary>
    /// Executes the core transaction logic after successful validation: deducts money,
    /// retrieves tickets, and assigns ownership.
    /// </summary>
    /// <param name="e">The Event from which tickets are taken.</param>
    /// <param name="nrOfTickets">The number of tickets to retrieve.</param>
    /// <param name="totalPrice">The amount to deduct from the user.</param>
    private void ProceedOnSuccess(Event e, int nrOfTickets, int totalPrice)
    {
        var tickets = e.GetRangeOfFreeTickets(nrOfTickets);
        
        User!.RemoveMoney(totalPrice);
        foreach (var ticket in tickets)
        {
            ticket.SetOwner(User);
            User.OwnedTickets.Add(ticket);
        }
    }
    
    /// <summary>
    /// Executes the entire ticket purchase process.
    /// </summary>
    /// <param name="e">The Event the user is purchasing tickets for.</param>
    /// <param name="nrOfTickets">The quantity of tickets to purchase.</param>
    /// <returns>A PurchaseResult enum indicating the outcome of the attempt.</returns>
    public PurchaseResult Handle(Event e, int nrOfTickets)
    {
        int totalPrice = e.Price * nrOfTickets;
        bool success = CheckPurchaseValid(e, nrOfTickets, totalPrice, out var result);

        if (success)
        {
            ProceedOnSuccess(e, nrOfTickets, totalPrice);
        }

        context.SaveChanges();
        return result;
    }
}