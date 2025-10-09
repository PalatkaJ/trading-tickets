namespace tickets_trading.Application.Authentication;

public interface IPasswordHasher
{
    (string Hash, string Salt) Hash(string password);
    bool Verify(string password, string storedHash, string storedSalt);
}