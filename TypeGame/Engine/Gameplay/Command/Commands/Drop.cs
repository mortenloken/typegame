using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Drop(string item) : ICommand
{
    public static ICommand? Accept(string input)
    {
        var parts = input.Split(' ');
        if (input.StartsWith("slipp") && parts.Length == 2)
        {
            return new Drop(parts[1]);
        }

        return default;
    }

    public Consequence Execute(Game game)
    {
        //resolve the item
        var inventoryItem = game.Player.Inventory.Get(item);
        if(inventoryItem == default) {
            GameConsole.Error("Det du vil slippe er ikke noe du har.");
        }
        else
        {
            //do the transaction
            var scene = game.GetCurrentScene();
            var count = inventoryItem.Count;
            game.Player.Inventory.TransferTo(scene.Inventory, inventoryItem.Item, count);

            //inform
            GameConsole.Confirm($"Du slipper {count} {inventoryItem.Item.Name.ToLower()}.");
        }

        return new Consequence
        {
            Duration = TimeSpan.FromSeconds(5),
            Command = new Inventory()
        };
    }
}
