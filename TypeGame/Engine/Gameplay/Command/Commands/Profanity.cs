using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Profanity(string input) : ICommand
{
    private static readonly string[] Profanities = ["faen", "dust", "idiot", "fuck", "kuk"];

    public static ICommand? Accept(string input)
        => Profanities.Contains(input.Trim(), StringComparer.InvariantCultureIgnoreCase)
            ? new Profanity(input)
            : default;

    public Consequence Execute(Game game)
    {
        GameConsole.Info($"{input.ToUpper()} kan du være selv!");
        return Consequence.None;
    }
}
