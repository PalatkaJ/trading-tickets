namespace tickets_shop.Domain.Users;

public abstract class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    
    public void SetFields(string username, string hash)
    {
        Username = username;
        PasswordHash = hash;
    }

    public abstract string GetRole { get; }
    
    // Required for EF Core to materialize the object
    public User() { }
}