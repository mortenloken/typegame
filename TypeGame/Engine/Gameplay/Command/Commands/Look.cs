using TypeGame.Engine.Console;
using TypeGame.Engine.Util;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Look : ICommand
{
    public static ICommand? Accept(string input) 
        => input.Equals("se", StringComparison.InvariantCulture)
            ? new Look()
            : default;

    public Consequence Execute(Game game)
    {
        var scene = game.GetCurrentScene();
        GameConsole.Info(scene.Description);
        GameConsole.Info($"{scene.Preposition.Capitalize()} {scene.Name.ToLower()} ligger det {scene.Inventory}.");
        return Consequence.None;
    }
}
