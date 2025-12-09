using tickets_shop.Domain.Tickets;

namespace tickets_shop.Application.DatabaseAPI;

public interface ITicketsRepository
{
    public void AddTicket(Ticket ticket);

    public Ticket? GetTicketById(Guid id);
    
}