namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Quit : ICommand
{
    private static readonly string[] Inputs = ["stopp", "slutt", "avslutt", "quit", "exit"];
    
    public static ICommand? Accept(string input)
        => Inputs.Contains(input.Trim(), StringComparer.InvariantCultureIgnoreCase)
            ? new Quit()
            : default;

    public Consequence Execute(Game game) 
        => Consequence.Quit;
}
