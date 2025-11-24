using tickets_trading.UI.Core.View;

namespace tickets_trading.UI.Features.Menus.MenuView;

public class MenuView: ConsoleViewBase, IMenuView
{
    public IReadOnlyList<MenuItem>? Options { private get; set; }
    
    protected override void DisplayBody()
    {
        if (Options is null) throw new ArgumentNullException(nameof(Options));

        foreach (var menuItem in Options)
        {
            ShowMessage(menuItem + "\n");
        }
    }

    private bool IndexIsValid(int idx)
    {
        return idx >= 1 && idx <= Options!.Count;
    }
    
    public MenuItem ChooseOption()
    {
        if (Options is null) throw new ArgumentNullException(nameof(Options));

        bool invalidOption = false;
        
        while (true)
        {
            DisplayContent();
            
            if (invalidOption) ShowMessage("Invalid option. Try again.\n");
            
            var optionId = GetInput("Select: ");
            if (int.TryParse(optionId, out var idx) && IndexIsValid(idx))
            {
                // we cant use just Options[idx] because we have other items in the list
                // other than choosable by user (such as empty lines)
                return Options.First(o => o.Id == idx);
            }

            invalidOption = true;
        }
    }
}