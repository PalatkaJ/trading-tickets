using tickets_trading.Application;
using tickets_trading.Domain;

namespace tickets_trading.UI;

public class ConsoleAppController(AuthService authService)
{
    private AuthService _authService = authService;
    private User? _currentUser;
    private bool _running = true;

    public void Run()
    {
        // POZN. od vsude bude vzdy readline pro uzivatele, coz je blokujici volani, diky kteremu se nebude vypisovat
        // furt dokola treba to stejne menu
        // (vzdy po vypsani cekam na jeho input abych zmenil nejak svuj vnitrni stav a projedu dalsi loop)
        while (_running)
        {
            if (_currentUser is null) {ShowAuthenticationMenu(); continue;}
            ShowMainMenu();
        }
    }

    private void ShowAuthenticationMenu()
    {
        Console.WriteLine("1. Sign Up\n2. Log In\n3. Help\n4. Exit");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1": HandleSignUp(); break;
            case "2": HandleLogIn(); break;
            case "3": break; //TODO display some help for the user
            case "4": Environment.Exit(0); break;
        }
    }

    private (string username, string password) GetCredentials()
    {
        Console.Write("Username: ");
        var username = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        return (username!, password!);
    }
    
    private void HandleSignUp()
    {
        Console.Write("Sign up as an admin? [y/n]: ");
        var option = Console.ReadLine();
        var (username, password) = GetCredentials();
        bool isAdmin = false;
        switch (option)
        {
            case "y": _currentUser = _authService.SignUp<Admin>(username, password); break;
            case "n": _currentUser = _authService.SignUp<User>(username, password); break;
        }
    }

    private void HandleLogIn()
    {
        var (username, password) = GetCredentials();
        _currentUser = _authService.LogIn(username, password);
    }

    private void ShowMainMenu()
    {
        Console.WriteLine($"Current user: {_currentUser}");
        Environment.Exit(0);
    }
}