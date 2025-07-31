using System.Diagnostics;
using tickets_trading.Application;
using tickets_trading.Infrastructure;

namespace tickets_trading;

class Program
{
    static void Main(string[] args)
    {
        using var db = AppDbContext.Create();
        db.Database.EnsureCreated();
        
        var hasher = new Pbkdf2PasswordHasher();
        var userRepo = new UserRepository(db);
        var authService = new AuthService(userRepo, hasher);
        
        Console.Write("Sign Up/ Log In [s/l]: ");
        int input = Console.Read();
        Console.Write("Enter Username: ");
        var username = Console.ReadLine();
        while (username == "")
        {
            username = Console.ReadLine();
        }
        Console.Write("Enter Password: ");
        var passwd = Console.ReadLine();
        while (passwd == "")
        {
            passwd = Console.ReadLine();
        }
        switch (input)
        {
            case -1:
                break;
            case (int)'s':
                authService.SignUp(username!, passwd!);
                Console.WriteLine("Successfully signed up");
                break;
            case (int)'l':
                authService.LogIn(username!, passwd!);
                Console.WriteLine("Successfully logged in");
                break;
        }
    }
}
