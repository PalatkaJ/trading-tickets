using tickets_trading.Domain.Authentication;

namespace tickets_trading.Domain;


// TODO change Event so the ticket cost is there and not at the ticket
public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string? Title { get; private set; }
    
    public string? Description { get; private set; }
    public int Price { get; private set; }
    public string Currency => "Czk";

    public DateTime? Date { get; private set; }
    public string? Place { get; private set; }

    public Admin? Organizer { get; private set; }
    public Guid? OrganizerId { get; private set; }

    public int CurrentFreeTicket { get; private set; } 
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    

    public override string ToString()
    {
        return $"""
                Title:        {Title}
                Description:  {Description}
                Date:         {Date!.Value:dd MMM yyyy HH:mm}
                Place:        {Place}

                Organizer:    {Organizer!.Username}

                Tickets:      {Tickets.Count - CurrentFreeTicket}/{Tickets.Count} available
                Price:        {Price} {Currency}
                """;
    }
    
    public void SetFields(string title, string description, DateTime date, string place, int numberOfTickets, int price)
    {
        Title = title;
        Description = description;
        Date = date;
        Place = place;
        Price = price;
        CurrentFreeTicket = 0;
        GenerateTickets(numberOfTickets);
    }

    public void SetOrganizer(Admin admin)
    {
        Organizer = admin;
        OrganizerId = admin.Id;
    }
    
    private void GenerateTickets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ticket ticket = new();
            ticket.SetFields($"Seat-{i + 1}", this);
            Tickets.Add(ticket);
        }
    }

    public bool TicketIsAvailable() => CurrentFreeTicket < Tickets.Count;

    public Ticket GetATicket()
    {
        return Tickets.ElementAt(CurrentFreeTicket++);
    }
    
    // for EF core
    public Event() { }
}