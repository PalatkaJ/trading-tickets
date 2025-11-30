namespace tickets_trading.Domain;

public class Admin : User
{
    public ICollection<Event> OrganizedEvents { get; private set; } = new List<Event>();

    protected override string GetRole => "Admin";

    public override string ToString()
    {
        return base.ToString() + $"""
                
                
                Managed Events: {OrganizedEvents?.Count ?? 0}
                """;
    }
}