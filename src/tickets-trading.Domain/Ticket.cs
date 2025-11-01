using tickets_trading.Domain.Authentication;

namespace tickets_trading.Domain;

public class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string? Seat { get; set; }

    public int Price;
    
    public RegularUser? TicketOwner { get; set; }
    public Guid? TicketOwnerId { get; set; }
    
    public Event? Event { get; set; }
    public Guid? EventId { get; set; }

    public override string ToString()
    {
        return Event + $": ticket number [{Seat}]";
    }

    public void SetFields(string seat, int price, Event e)
    {
        Seat = seat;
        Price = price;
        Event = e;
    }

    //for EF core
    public Ticket() { }
}