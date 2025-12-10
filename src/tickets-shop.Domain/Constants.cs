namespace tickets_shop.Domain;

/// <summary>
/// Application-wide constants, such as window width,
/// currency or app title.
/// </summary>
public static class AppConstants
{
    public const string Currency = "czk";
    public const string AppName = "tickets shop";
    public const char HeadTitleBoarder = '=';
    public const char SubTitleBoarder = '─';
    public const int WindowWidth = 45;
}

/// <summary>
/// Titles of menus that are present in the application.
/// </summary>
public static class SiteNames
{
    public const string Main = "Main Menu";
    public const string AdminEventsBrowser = "Browse Created Events";
    public const string AdminEvents = "Events";
    public const string AccountInfo = "Account Information";
    public const string RegBrowseEvents = "Browse Available Events";
    public const string RegEventSub = "Tickets Purchase";
    public const string RegTicketsBrowse = "My Tickets";
    public const string RegTicketsShop = "Tickets Shop";
    public const string Auth = "Authentication";
    public const string SignUp = "Sign Up";
    public const string AddMoney = "Add Money";
    public const string Help = "Help";
}

public static class ErrorMessages
{
    public const string InvalidPassword = "Invalid password.";
    public const string UserNotFound = "User not found. Please sign up first.";
    public const string UserAlreadyExists = "User already exists. Please use log in.";
    public const string NumberOverflow = "Provided number was either too large or too small.";
    public const string NumberInvalidFormat = "Please enter a valid decimal positive number.";
    public const string NotEnoughTickets = "There are no tickets left for this event.";
    public const string NotEnoughMoney =
        "You don't have enough money in your account.\nPlease recharge money in account information tab.";
}

public static class UserRoles
{
    public const string Admin = "Admin";
    public const string RegularUser = "Regular User";
}