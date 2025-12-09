using tickets_shop.Domain.Events;
using tickets_shop.Domain.Users;

namespace tickets_shop.Domain.Tickets;

public class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public int Seat { get; set; }
    
    public RegularUser? TicketOwner { get; set; }
    public Guid? TicketOwnerId { get; set; }
    
    public Event? Event { get; set; }
    public Guid? EventId { get; set; }
    
    public void SetFields(int seat, Event e)
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