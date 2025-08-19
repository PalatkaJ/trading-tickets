using tickets_trading.Application;
using tickets_trading.Domain;
using tickets_trading.UI.View;
using tickets_trading.UI.View.Menu;
using tickets_trading.UI.View.Menu.MenuBuilders;

namespace tickets_trading.UI.Controller;

public class ConsoleAppController(AuthService authService,IView simpleView, IMenuView menuView, IMenuBuilder builder)
{
    private readonly AuthService _authService = authService;
    private User? _currentUser;
    private bool _running = true;
    private IMenuBuilder _menuBuilder = builder;
    
    
    public void Run()
    {
        // POZN. vsude bude vzdy readline pro uzivatele, coz je blokujici volani, diky kteremu se nebude vypisovat
        // furt dokola treba to stejne menu
        // (vzdy po vypsani cekam na jeho input abych zmenil nejak svuj vnitrni stav a projedu dalsi loop)
        while (_running)
        {
            SetMenuBuilder();
            var options = _menuBuilder.BuildMenu();
            menuView.Options = options;
            menuView.Display();
            var option = menuView.ChooseOption();
            option.Service.Execute();
            //ShowMainMenu();
        }
    }

    private void SetMenuBuilder()
    {
        if (_currentUser is null) { _menuBuilder = new AuthenticationMenuBuilder(simpleView, menuView); return; }
        _menuBuilder = _currentUser is Admin ? new AdminMenuBuilder(simpleView, menuView) : new UserMenuBuilder(simpleView, menuView);
    }

    /*
    private void ShowAuthenticationMenu()
    {
        var option = _authView.GetInput("1. Sign Up\n2. Log In\n3. Help\n4. Exit\n");
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
        var username = _authView.GetInput("Username: ");
        var password = _authView.GetInput("Password: ");
        return (username!, password!);
    }
    
    private void HandleSignUp()
    {
        var option = _authView.GetInput("Sign up as an admin? [y/n]: ");
        var (username, password) = GetCredentials();
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
        _userView!.ShowMainMenu();
        var option = _userView.GetInput();
    }
    */
}