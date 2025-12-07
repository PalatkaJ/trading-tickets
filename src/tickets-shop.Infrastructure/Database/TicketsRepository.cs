using tickets_shop.Domain;
using tickets_shop.Application.DatabaseAPI;

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