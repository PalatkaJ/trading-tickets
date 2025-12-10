using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain;
using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;

namespace tickets_shop.Application.ServiceHandlers;

public enum PurchaseResult
{
    Success,
    NoTicketsAvailable,
    NotEnoughMoney
}

public class TicketsPurchaseHandler(DbContext context)
{
    public RegularUser? User;

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