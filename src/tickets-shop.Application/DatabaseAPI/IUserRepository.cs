using tickets_shop.Domain.Users;

namespace tickets_shop.Application.DatabaseAPI;

/// <summary>
/// Defines the contract for a repository of users
/// and specific loading patterns related to User entities.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Adds a new User entity (Admin or RegularUser) to the database context.
    /// </summary>
    /// <param name="user">The User object to add.</param>
    public void AddUser(User user);
    
    /// <summary>
    /// Retrieves a User entity based on its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the user to retrieve.</param>
    /// <returns>The User object, or null if not found.</returns>
    public User? GetUserById(Guid id);
    
    /// <summary>
    /// Retrieves a User entity based on its username without loading its complex navigation properties.
    /// Used primarily for authentication checks where only the username and password hash are needed.
    /// So this loads really only the user, not tickets or events related to that user.
    /// </summary>
    /// <param name="username">The username to search for.</param>
    /// <returns>The User object, or null if not found.</returns>
    public User? GetUserByUsernameLight(string username);

    /// <summary>
    /// Explicitly loads dependencies of a user.
    /// This method is typically used to load collections like OwnedTickets or OrganizedEvents.
    /// </summary>
    /// <param name="user">The tracked User object whose dependencies should be loaded.</param>
    public void EagerLoadUsersDependencies(User user);
}