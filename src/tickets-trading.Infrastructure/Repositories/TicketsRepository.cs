using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;
using tickets_trading.Infrastructure.Database;

namespace tickets_trading.Infrastructure.Repositories;

public class TicketsRepository(AppDbContext context): ITicketsRepository
{
    public void AddTicket(Ticket ticket)
    {
        context.Attach(ticket.Event);
        context.Attach(ticket.TicketOwner);
        context.Tickets.Add(ticket);
        context.SaveChanges();
    }

    public Ticket? GetTicketById(Guid id) => context.Tickets.Find(id);
}