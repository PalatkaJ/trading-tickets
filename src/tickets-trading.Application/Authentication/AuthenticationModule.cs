using Microsoft.AspNetCore.Identity;
using tickets_trading.Application.DatabaseAPI;
using tickets_trading.Domain;

namespace tickets_trading.Application.Authentication;

public class AuthenticationModule(IUserRepository userRepo,  IPasswordHasher<User> hasher)
{
    public User SignUp<TUser>(string username, string password) where TUser: User, new() {
        var user = userRepo.GetUserByUsernameLight(username);
        if (user is not null) throw new InvalidOperationException("User already exists. Please use log in.");
        
        user = new TUser();
        var hashedPasswd = hasher.HashPassword(user!, password);
        user.SetFields(username, hashedPasswd);
        
        userRepo.AddUser(user);
        return user;
    }

    public User LogIn(string username, string password) {
        var user = userRepo.GetUserByUsernameLight(username) ?? throw new InvalidOperationException("User not found. Please sign up first.");
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        switch (result)
        {
            case PasswordVerificationResult.Failed:
                throw new UnauthorizedAccessException("Incorrect password.");
            case PasswordVerificationResult.Success:
                break;
            case PasswordVerificationResult.SuccessRehashNeeded:
                var hashedPasswd = hasher.HashPassword(user, password);
                user.SetFields(username, hashedPasswd);
                break;
        }
        userRepo.LoadUsersDependencies(user);
        return user;
    }
}