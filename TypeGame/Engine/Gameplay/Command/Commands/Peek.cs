using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Peek(bool details) : ICommand
{
    public static ICommand? Accept(string input)
        => input.Equals("hvor", StringComparison.InvariantCulture)
            ? new Peek(true)
            : default;

    public Consequence Execute(Game game)
    {
        var scene = game.GetCurrentScene();
        if (details)
        {
            GameConsole.Info($"Du er {scene.Preposition} {scene.Name.ToLower()}.");
        }
        return Consequence.None;
    }
}
