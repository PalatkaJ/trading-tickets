using tickets_shop.Domain.Events;

namespace tickets_shop.Domain.Users;

public class Admin : User
{
    public ICollection<Event> OrganizedEvents { get; private set; } = new List<Event>();

    protected override string GetRole => UserRoles.Admin;

    public override string ToString()
    {
        return base.ToString() + $"""
                
                
                Managed Events: {OrganizedEvents?.Count ?? 0}
                """;
    }
}