using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class NotUnderstood : ICommand
{
    public static ICommand? Accept(string input) => default;

    public Consequence Execute(Game game)
    {
        GameConsole.Error("Jeg forstod ikke hva du mente. Prøv igjen.");
        return Consequence.None;
    }
}
