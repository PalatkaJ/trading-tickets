namespace tickets_trading.Domain;


// TODO change Event so the ticket cost is there and not at the ticket
public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string? Title { get; private set; }

    public string? Description { get; private set; }
    public long Price { get; private set; }
    public string Currency => "Czk";

    public DateTime? Date { get; private set; }
    public string? Place { get; private set; }

    public Admin? Organizer { get; private set; }
    public Guid? OrganizerId { get; private set; }

    public int CurrentFreeTicket { get; private set; }
    public int TicketsCount { get; private set; }

public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();

    public override string ToString()
    {
        return $"""
                Title:        {Title}
                
                Description:  {Description}
                Date:         {Date!.Value:dd MMM yyyy HH:mm}
                Place:        {Place}

                Tickets:      {TicketsCount - CurrentFreeTicket}/{TicketsCount} available
                Price:        {Price} {Currency}
                """;
    }
    
    public void SetFields(string title, string description, DateTime date, string place, int numberOfTickets, long price)
    {
        Title = title;
        Description = description;
        Date = date;
        Place = place;
        Price = price;
        CurrentFreeTicket = 0;
        TicketsCount = numberOfTickets;
        GenerateTickets();
    }

    public void SetOrganizer(Admin admin)
    {
        Organizer = admin;
        OrganizerId = admin.Id;
    }
    
    private void GenerateTickets()
    {
        for (int i = 0; i < TicketsCount; i++)
        {
            Ticket ticket = new();
            ticket.SetFields($"Seat-{i + 1}", this);
            Tickets.Add(ticket);
        }
    }

    public bool TicketsAreAvailable(int nrOfTickets) => CurrentFreeTicket + nrOfTickets - 1 < Tickets.Count;

    public List<Ticket> GetTickets(int nr)
    {
        return Tickets.Take(new Range(CurrentFreeTicket+nr, nr)).ToList();
    }
    
    // for EF core
    public Event() { }
}