using tickets_trading.Domain.Authentication;

namespace tickets_trading.Domain;

public class Event
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string? Title { get; private set; }

    public string? Description { get; private set; }

    public DateTime? Date { get; private set; }
    public string? Place { get; private set; }

    public Admin? Organizer { get; private set; }
    public Guid? OrganizerId { get; set; }
    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    

    public override string ToString()
    {
        return Title;
    }
    
    public void SetFields(string title, string description, DateTime date, string place, 
        Admin organizer, int numberOfTickets, int price)
    {
        Title = title;
        Description = description;
        Date = date;
        Place = place;
        Organizer = organizer;
        OrganizerId = Organizer.Id;
        GenerateTickets(numberOfTickets, price);
    }
    
    private void GenerateTickets(int count, int price)
    {
        for (int i = 0; i < count; i++)
        {
            Ticket ticket = new();
            ticket.SetFields($"Seat-{i + 1}", price, this);
            Tickets.Add(ticket);
        }
    }
    
    // for EF core
    public Event() { }
}