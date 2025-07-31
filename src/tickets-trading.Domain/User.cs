namespace tickets_trading.Domain;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }

    // Required for EF Core to materialize the object
    private User() { }

    public User(Guid id, string username, string hash, string salt)
    {
        Id = id;
        Username = username;
        PasswordHash = hash;
        PasswordSalt = salt;
    }
}

