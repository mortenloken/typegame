namespace TypeGame.Engine.Gameplay.Command.Commands;

public class None : ICommand
{
    public static ICommand? Accept(string input)
        => string.IsNullOrEmpty(input.Trim())
            ? new None()
            : default;

    public Consequence Execute(Game game)
        => new()
        {
            Command = new Peek(true)
        };
}
