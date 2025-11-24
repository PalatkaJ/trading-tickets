using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;
using tickets_trading.Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace tickets_trading.Application.ServiceHandlers;

public enum PurchaseResult
{
    Success,
    NoTicketsAvailable,
    NotEnoughMoney
}

public class TicketsPurchaseHandler(DbContext context)
{
    public RegularUser? User;
    
    public PurchaseResult Handle(Event e)
    {
        if (!e.TicketIsAvailable()) return PurchaseResult.NoTicketsAvailable;
        if (!User!.HasEnoughMoney(e.Price)) return PurchaseResult.NotEnoughMoney;
        
        var ticket = e.GetATicket();
        
        User.Buy(e.Price);
        ticket.SetOwner(User);
        User.OwnedTickets.Add(ticket);

        context.SaveChanges();
        return PurchaseResult.Success;
    }
}