namespace TypeGame.Engine.Gameplay.Command;

public class Inventory : ICommand
{
    public static ICommand? Accept(string input)
        => input.Equals("lomma", StringComparison.InvariantCulture)
            ? new Inventory()
            : default;

    public Consequence Perform(Game game)
    {
        Console.WriteLine($"Du har {game.Player.Inventory}.");        
        return Consequence.None;
    }

    public TimeSpan Duration => TimeSpan.Zero;
}
