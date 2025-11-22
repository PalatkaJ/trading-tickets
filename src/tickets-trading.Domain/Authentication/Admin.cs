namespace tickets_trading.Domain.Authentication;

public class Admin : User
{
    //TODO Load from db
    public ICollection<Event> OrganizedEvents { get; private set; } = new List<Event>();
}