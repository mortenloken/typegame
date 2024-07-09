using TypeGame.Engine.Console;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Walk(string to) : ICommand
{
    public static ICommand? Accept(string input)
    {
        var parts = input.Split(' ');
        if (input.StartsWith("gå") && parts.Length == 2)
        {
            return new Walk(parts[1]);
        }
        if (input.StartsWith("gå til") && parts.Length == 3)
        {
            return new Walk(parts[2]);
        }

        return default;
    }

    public Consequence Execute(Game game)
    {
        var fromScene = game.GetCurrentScene();
        var toScene = game.GetScene(to);
        if(toScene == null) {
            GameConsole.Error($"'{to}' er ikke et sted jeg kjenner til.");
        }
        else if(toScene == fromScene) {
            GameConsole.Error($"Du er allerede {fromScene.Preposition} {fromScene.Name}.");
        }
        else if (!fromScene.IsConnectedTo(toScene))
        {
            GameConsole.Error($"Du går ikke an å gå fra {fromScene.Name.ToLower()} til {toScene.Name.ToLower()}.");
        }
        else
        {
            //move the player
            fromScene.Remove(game.Player);
            toScene.Add(game.Player);
        
            //inform
            GameConsole.Confirm($"Du går fra {fromScene.Name.ToLower()} til {toScene.Name.ToLower()}.");
        }
        
        return Consequence.Durate(TimeSpan.FromMinutes(1));
    }
}
