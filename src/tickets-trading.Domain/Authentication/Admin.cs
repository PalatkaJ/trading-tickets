namespace tickets_trading.Domain.Authentication;

public class Admin : User
{
    public List<Event> OrganizedEvents { get; private set; } = new();
}