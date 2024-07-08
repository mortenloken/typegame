namespace TypeGame.Engine.Gameplay.Command;

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

    public Consequence Perform(Game game)
    {
        //resolve the item
        var inventoryItem = game.Player.Inventory.Get(item);
        if(inventoryItem == default) {
            Console.WriteLine("Det du vil slippe er ikke noe du har.");
        }
        else
        {
            //do the transaction
            var scene = game.GetCurrentScene();
            var count = inventoryItem.Count;
            game.Player.Inventory.Remove(inventoryItem.Item, count);
            scene.Inventory.Add(inventoryItem.Item, count);

            //inform
            Console.WriteLine($"Du slipper {count} {inventoryItem.Item.Name.ToLower()}.");
        }

        return Consequence.WithCommand(new Inventory());
    }

    public TimeSpan Duration => TimeSpan.FromSeconds(3);    
}
