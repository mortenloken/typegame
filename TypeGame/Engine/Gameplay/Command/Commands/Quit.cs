namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Quit : ICommand
{
    public static ICommand? Accept(string input)
        => input.Equals("slutt", StringComparison.InvariantCulture)
            ? new Quit()
            : default;

    public Consequence Perform(Game game) 
        => Consequence.Quit;

    public TimeSpan Duration => TimeSpan.Zero;
}
