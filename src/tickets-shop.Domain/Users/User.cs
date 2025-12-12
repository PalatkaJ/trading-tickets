namespace tickets_shop.Domain.Users;

/// <summary>
/// Provides the abstract base definition for all user types (e.g., Admin, RegularUser)
/// in the application. It contains common user fields.
/// </summary>
public abstract class User
{
    /// <summary>
    /// The unique identifier for the user instance. Automatically generated upon creation.
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public string? Username { get; private set; }

    /// <summary>
    /// The cryptographic hash of the user's password for secure storage.
    /// </summary>
    public string? PasswordHash { get; private set; }

    /// <summary>
    /// Initializes the core identity fields of the User object.
    /// </summary>
    /// <param name="username">The user's unique username.</param>
    /// <param name="hash">The hashed version of the user's password.</param>
    public void SetFields(string username, string hash)
    {
        Username = username;
        PasswordHash = hash;
    }

    /// <summary>
    /// Gets the role associated with the specific concrete user type.
    /// </summary>
    public abstract string GetRole { get; }

    /// <summary>
    /// Parameterless constructor required by Entity Framework Core to create objects from database records.
    /// </summary>
    public User() { }
}