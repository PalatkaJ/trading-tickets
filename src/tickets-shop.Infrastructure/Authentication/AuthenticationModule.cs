using Microsoft.AspNetCore.Identity;
using tickets_shop.Application.Authentication;
using tickets_shop.Application.DatabaseAPI;
using tickets_shop.Domain;
using tickets_shop.Domain.Users;

namespace tickets_shop.Infrastructure.Authentication;

public class AuthenticationModule(IUserRepository userRepo,  IPasswordHasher<User> hasher): IAuthenticationModule
{
    public User SignUp<TUser>(string username, string password) where TUser: User, new() {
        var user = userRepo.GetUserByUsernameLight(username);
        if (user is not null) throw new InvalidOperationException(ErrorMessages.UserAlreadyExists);
        
        user = new TUser();
        var hashedPasswd = hasher.HashPassword(user!, password);
        user.SetFields(username, hashedPasswd);
        
        userRepo.AddUser(user);
        return user;
    }

    public User LogIn(string username, string password) {
        var user = userRepo.GetUserByUsernameLight(username) ?? throw new InvalidOperationException(ErrorMessages.UserNotFound);
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        switch (result)
        {
            case PasswordVerificationResult.Failed:
                throw new UnauthorizedAccessException(ErrorMessages.InvalidPassword);
            case PasswordVerificationResult.Success:
                break;
            case PasswordVerificationResult.SuccessRehashNeeded:
                var hashedPasswd = hasher.HashPassword(user, password);
                user.SetFields(username, hashedPasswd);
                break;
        }
        return user;
    }
}