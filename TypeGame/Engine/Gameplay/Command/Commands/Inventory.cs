using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

/// <summary>
/// This command is used to display the player's inventory.
/// </summary>
public class Inventory : ICommand
{
    public static ICommand? Accept(string input)
        => input.Equals("lomma", StringComparison.InvariantCulture)
            ? new Inventory()
            : default;

    public Consequence Execute(Game game)
    {
        GameConsole.Info($"Du har {game.Player.Inventory}.");
        return Consequence.None;
    }
}
