namespace tickets_trading.Domain.Authentication;

public abstract class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    
    public void SetFields(string username, string hash, string salt)
    {
        Username = username;
        PasswordHash = hash;
        PasswordSalt = salt;
    }
    
    public override string ToString()
    {
        return Username + $" ({GetType().Name}, id: " + Id + ")";
    }
    
    // Required for EF Core to materialize the object
    public User() { }
}

