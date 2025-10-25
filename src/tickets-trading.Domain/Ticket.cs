using tickets_trading.Domain.Authentication;

namespace tickets_trading.Domain;

public class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public int TicketNumber { get; private set; }
    
    public Event Event { get; private set; }

    public override string ToString()
    {
        return Event + $": ticket number [{TicketNumber}]";
    }

    public void SetFields(int ticketNumber, Event e)
    {
        TicketNumber = ticketNumber;
        Event = e;
    }

    //for EF core
    public Ticket() { }
}