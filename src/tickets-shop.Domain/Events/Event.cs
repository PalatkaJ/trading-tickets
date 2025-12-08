using tickets_shop.Domain.Tickets;
using tickets_shop.Domain.Users;

namespace tickets_shop.Domain.Events;

public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string? Title { get; private set; }

    public string? Description { get; private set; }
    public int Price { get; private set; }

    public DateTime? Date { get; private set; }
    public string? Place { get; private set; }

    public Admin? Organizer { get; private set; }
    public Guid? OrganizerId { get; private set; }

    public int CurrentFreeTicket { get; private set; }
    public int TicketCount { get; private set; }

    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();

    public override string ToString()
    {
        return $"""
                Title:        {Title}
                
                Description:  {Description}
                Date:         {Date!.Value:dd MMM yyyy HH:mm}
                Place:        {Place}

                Tickets:      {TicketCount - CurrentFreeTicket}/{TicketCount} available
                Price:        {Price} {AppConstants.Currency}
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
        TicketCount = numberOfTickets;
        GenerateTickets();
    }

    public void SetOrganizer(Admin admin)
    {
        Organizer = admin;
        OrganizerId = admin.Id;
    }
    
    private void GenerateTickets()
    {
        for (int i = 0; i < TicketCount; i++)
        {
            Ticket ticket = new();
            ticket.SetFields($"Seat-{i + 1}", this);
            Tickets.Add(ticket);
        }
    }

    public bool TicketsAreAvailable(int nrOfTickets) => CurrentFreeTicket + nrOfTickets - 1 < TicketCount;

    public List<Ticket> GetTickets(int nr)
    {
        var range = new Range(CurrentFreeTicket, CurrentFreeTicket+nr);
        var toReturn =  Tickets.Take(range).ToList();
        CurrentFreeTicket += nr;
        
        return toReturn;
    }
    
    // for EF core
    public Event() { }
}