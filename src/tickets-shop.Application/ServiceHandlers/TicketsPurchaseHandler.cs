using Microsoft.EntityFrameworkCore;
using tickets_shop.Domain;

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
    
    public PurchaseResult Handle(Event e, int nrOfTickets)
    {
        long totalPrice = e.Price * nrOfTickets;
        if (!e.TicketsAreAvailable(nrOfTickets)) return PurchaseResult.NoTicketsAvailable;
        if (!User!.HasEnoughMoney(totalPrice)) return PurchaseResult.NotEnoughMoney;
        
        var tickets = e.GetTickets(nrOfTickets);
        
        User.RemoveMoney(totalPrice);
        foreach (var ticket in tickets)
        {
            ticket.SetOwner(User);
            User.OwnedTickets.Add(ticket);
        }

        context.SaveChanges();
        return PurchaseResult.Success;
    }
}