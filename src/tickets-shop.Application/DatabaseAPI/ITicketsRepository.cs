using tickets_shop.Domain.Tickets;

namespace tickets_shop.Application.DatabaseAPI;

/// <summary>
/// Defines the contract for persistence operations specifically targeting
/// the Ticket entity.
/// </summary>
public interface ITicketsRepository
{
    /// <summary>
    /// Adds a single new Ticket entity to the database context.
    /// </summary>
    /// <param name="ticket">The Ticket object to be added.</param>
    public void AddTicket(Ticket ticket);

    /// <summary>
    /// Retrieves a single Ticket entity using its unique identifier.
    /// </summary>
    /// <param name="id">The GUID of the ticket to retrieve.</param>
    /// <returns>The Ticket object, or null if not found.</returns>
    public Ticket? GetTicketById(Guid id);
}