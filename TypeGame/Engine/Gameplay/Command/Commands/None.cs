namespace TypeGame.Engine.Gameplay.Command.Commands;

public class None : ICommand
{
    public static ICommand? Accept(string input) 
        => string.IsNullOrEmpty(input.Trim())
            ? new None()
            : default;

    public Consequence Perform(Game game) 
        => Consequence.WithCommand(new Peek(true));

    public TimeSpan Duration => TimeSpan.Zero;
}
