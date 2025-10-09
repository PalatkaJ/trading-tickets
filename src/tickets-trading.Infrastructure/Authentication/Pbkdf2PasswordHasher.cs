using System.Security.Cryptography;
using tickets_trading.Application.Authentication;

namespace tickets_trading.Infrastructure.Authentication;

public class Pbkdf2PasswordHasher : IPasswordHasher
{
    public (string Hash, string Salt) Hash(string password)
    {
        byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
        string salt = Convert.ToBase64String(saltBytes);

        var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
        string hash = Convert.ToBase64String(pbkdf2.GetBytes(32));

        return (hash, salt);
    }

    public bool Verify(string password, string storedHash, string storedSalt)
    {
        byte[] saltBytes = Convert.FromBase64String(storedSalt);
        var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
        string computedHash = Convert.ToBase64String(pbkdf2.GetBytes(32));
        return computedHash == storedHash;
    }
}
