using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain.Tickets;

namespace tickets_shop.Infrastructure.Database;

/// <summary>
/// Implements the ITicketsRepository contract using Entity Framework Core to
/// provide simple persistence and retrieval operations for the Ticket domain entity.
/// </summary>
/// <param name="context">The application's database context used to interact with the data store.</param>
public class TicketsRepository(AppDbContext context): ITicketsRepository
{
    public void AddTicket(Ticket ticket)
    {
        context.Tickets.Add(ticket);
        context.SaveChanges();
    }
    
    public Ticket? GetTicketById(Guid id) => context.Tickets.Find(id);
}