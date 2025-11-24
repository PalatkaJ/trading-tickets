using tickets_trading.Domain;

namespace tickets_trading.Application.DatabaseAPI;

public interface ITicketsRepository
{
    public void AddTicket(Ticket ticket);

    public Ticket? GetTicketById(Guid id);
    
}