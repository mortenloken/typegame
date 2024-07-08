using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Take(string item) : ICommand
{
    public static ICommand? Accept(string input)
    {
        var parts = input.Split(' ');
        if (input.StartsWith("ta") && parts.Length == 2)
        {
            return new Take(parts[1]);
        }

        return default;
    }

    public Consequence Execute(Game game)
    {
        var from = game.GetCurrentScene();
        var inventoryItem = from.Inventory.Get(item);
        if (inventoryItem == default)
        {
            GameConsole.Error("Det du vil ta finnes ikke her.");
        }
        else
        {
            //do the transaction
            var count = inventoryItem.Count;
            from.Inventory.TransferTo(game.Player.Inventory, inventoryItem.Item, count);

            //inform
            GameConsole.Confirm($"Du tar {count} {inventoryItem.Item.Name.ToLower()}.");
        }

        return new Consequence
        {
            Duration = TimeSpan.FromSeconds(5),
            Command = new Inventory()
        };
    }
}
