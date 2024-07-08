﻿using TypeGame.Engine.Util;

namespace TypeGame.Engine.Gameplay.Command.Commands;

public class Look : ICommand
{
    public static ICommand? Accept(string input) 
        => input.Equals("se", StringComparison.InvariantCulture)
            ? new Look()
            : default;

    public Consequence Perform(Game game)
    {
        var scene = game.GetCurrentScene();
        Console.WriteLine(scene.Description);
        Console.WriteLine($"{scene.Preposition.Capitalize()} {scene.Name.ToLower()} ligger det {scene.Inventory}.");
        return Consequence.None;
    }

    public TimeSpan Duration => TimeSpan.Zero;
}
