using tickets_shop.Domain.Events;

namespace tickets_shop.Domain.Users;

public class Admin : User
{
    public ICollection<Event> OrganizedEvents { get; private set; } = new List<Event>();

    public override string GetRole => UserRoles.Admin;
}