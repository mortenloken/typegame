namespace TypeGame.Engine.Gameplay.Command;

public class Move(string to) : ICommand
{
    public static ICommand? Accept(string input)
    {
        var parts = input.Split(' ');
        if (input.StartsWith("gå") && parts.Length == 2)
        {
            return new Move(parts[1]);
        }
        if (input.StartsWith("gå til") && parts.Length == 3)
        {
            return new Move(parts[2]);
        }

        return default;
    }

    public Consequence Perform(Game game)
    {
        var fromScene = game.GetCurrentScene();
        var toScene = game.GetScene(to);
        if(toScene == null) {
            Console.WriteLine("Jeg forstår ikke hvor du vil gå.");
        }
        else if(toScene == fromScene) {
            Console.WriteLine($"Du er allerede {fromScene.Preposition} {fromScene.Name}.");
        }
        else
        {
            //move the player
            fromScene.Remove(game.Player);
            toScene.Add(game.Player);
        
            //inform
            Console.WriteLine($"Du går fra {fromScene.Name.ToLower()} til {toScene.Name.ToLower()}.");
        }
        
        return Consequence.None;
    }

    public TimeSpan Duration => TimeSpan.FromMinutes(1);
}
