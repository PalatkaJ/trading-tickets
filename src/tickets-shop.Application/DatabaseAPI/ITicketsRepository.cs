using tickets_shop.Domain;

namespace tickets_shop.Application.DatabaseAPI;

public interface ITicketsRepository
{
    public void AddTicket(Ticket ticket);

    public Ticket? GetTicketById(Guid id);
    
}