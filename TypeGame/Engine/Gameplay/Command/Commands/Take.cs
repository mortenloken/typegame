namespace TypeGame.Engine.Gameplay.Command;

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

    public Consequence Perform(Game game)
    {
        var from = game.GetCurrentScene();
        var inventoryItem = from.Inventory.Get(item);
        if(inventoryItem == default) {
            Console.WriteLine("Det du vil ta finnes ikke her.");
        }
        else
        {
            //do the transaction
            var count = inventoryItem.Count;
            from.Inventory.Remove(inventoryItem.Item, count);
            game.Player.Inventory.Add(inventoryItem.Item, count);

            //inform
            Console.WriteLine($"Du tar {count} {inventoryItem.Item.Name.ToLower()}.");
        }

        return Consequence.WithCommand(new Inventory());
    }

    public TimeSpan Duration => TimeSpan.FromSeconds(5);
}
