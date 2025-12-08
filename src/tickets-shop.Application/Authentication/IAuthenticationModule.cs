using tickets_shop.Domain.Users;

namespace tickets_shop.Application.Authentication;

public interface IAuthenticationModule
{
    User SignUp<TUser>(string username, string password) where TUser : User, new();
    
    User LogIn(string username, string password);
}