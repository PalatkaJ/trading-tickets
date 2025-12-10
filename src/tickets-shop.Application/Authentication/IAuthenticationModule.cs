using tickets_shop.Domain.Users;

namespace tickets_shop.Application.Authentication;

/// <summary>
/// Defines the contract for an authentication service responsible for
/// user registration and login operations.
/// </summary>
public interface IAuthenticationModule
{
    /// <summary>
    /// Registers a new user with the provided credentials.
    /// </summary>
    /// <typeparam name="TUser">
    /// The specific type of user to create (e.g., RegularUser or Admin).
    /// Must be a concrete type derived from User and have a parameterless constructor.
    /// </typeparam>
    /// <param name="username">The desired unique username.</param>
    /// <param name="password">The user's password (not hashed, SHOULD be hashed internally).</param>
    /// <returns>The newly created and persisted User object.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the username is already taken (user exists).</exception>
    User SignUp<TUser>(string username, string password) where TUser : User, new();
    
    /// <summary>
    /// Authenticates a user based on their username and password.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <param name="password">The user's raw password to verify.</param>
    /// <returns>The validated User object.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no user with the provided username exists.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown if the provided password does not match the stored hash.</exception>
    User LogIn(string username, string password);
}