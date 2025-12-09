using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Tickets;

namespace tickets_shop.Infrastructure.Database;

public class TicketsRepository(AppDbContext context): ITicketsRepository
{
    public void AddTicket(Ticket ticket)
    {
        context.Attach(ticket.Event!);
        context.Attach(ticket.TicketOwner!);
        context.Tickets.Add(ticket);
        context.SaveChanges();
    }

    public Ticket? GetTicketById(Guid id) => context.Tickets.Find(id);
}