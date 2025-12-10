using tickets_shop.Domain.Events;

namespace tickets_shop.Domain.Users;

/// <summary>
/// Represents an administrative user with privileges to create events.
/// </summary>
public class Admin : User
{
    /// <summary>
    /// A collection of events that have been organized and created by this specific administrator.
    /// </summary>
    public ICollection<Event> OrganizedEvents { get; private set; } = new List<Event>();

    /// <summary>
    /// Gets the role string constant defined for an Administrator.
    /// </summary>
    public override string GetRole => UserRoles.Admin;
}