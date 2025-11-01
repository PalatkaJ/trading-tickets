namespace tickets_trading.Domain.Authentication;

public class Admin : User
{
    //TODO Load from db
    public List<Event> OrganizedEvents { get; private set; } = new();
}