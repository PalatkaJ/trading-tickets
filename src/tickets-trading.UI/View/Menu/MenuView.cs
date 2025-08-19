namespace tickets_trading.UI.View.Menu;

public class MenuView: SimpleConsoleView, IMenuView
{

    public IReadOnlyList<MenuItem>? Options { private get; set; }
    
    protected override void DisplayBody()
    {
        if (Options is null) throw new ArgumentNullException(nameof(Options));
        
        for (int i = 0; i < Options.Count; ++i)
        {
            ShowMessage($"{i+1}. {Options[i].Title}\n");
        }
    }

    public MenuItem ChooseOption()
    {
        if (Options is null) throw new ArgumentNullException(nameof(Options));
        
        while (true)
        {
            var option = GetInput("Select: ");
            if (int.TryParse(option, out var idx) && idx >= 1 && idx <= Options.Count)
                return Options[idx - 1];

            ShowMessage("Invalid option. Try again.\n");
        }
    }
}