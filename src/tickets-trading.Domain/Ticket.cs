namespace tickets_trading.Domain;

public class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string? Seat { get; set; }
    
    public RegularUser? TicketOwner { get; set; }
    public Guid? TicketOwnerId { get; set; }
    
    public Event? Event { get; set; }
    public Guid? EventId { get; set; }

    public override string ToString()
    {
        return Event + $"\nSeat:         [{Seat}]";
    }
    
    public void SetFields(string seat, Event e)
    {
        Seat = seat;
        Event = e;
        EventId = e.Id;
    }

    public void SetOwner(RegularUser owner)
    {
        TicketOwner = owner;
        TicketOwnerId = owner.Id;
    }
    
    //for EF core
    public Ticket() { }
}