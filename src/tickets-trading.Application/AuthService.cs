using tickets_trading.Domain;

namespace tickets_trading.Application;

public class AuthService(IUserRepository userRepo, IPasswordHasher hasher)
{
    private readonly IUserRepository _userRepo = userRepo;
    private readonly IPasswordHasher _hasher = hasher;

    public User SignUp(string username, string password) {
        // validate, hash, save
        var user = _userRepo.GetUserByUsername(username);
        if (user is not null) throw new InvalidOperationException("User already exists.");
        
        var (hash, salt) = _hasher.Hash(password);
        user =  new User(Guid.NewGuid(), username, hash, salt);
        _userRepo.AddUser(user);
        return user;
    }

    public User? LogIn(string username, string password) {
        // check credentials
        var user = _userRepo.GetUserByUsername(username) ?? throw new InvalidOperationException("User not found.");
        if (!_hasher.Verify(password, user.PasswordHash, user.PasswordSalt)) throw new UnauthorizedAccessException("Incorrect password.");
        return user;
    }
}