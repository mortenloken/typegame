namespace TypeGame.Engine.Gameplay.Command.Commands;

public class NotUnderstood : ICommand
{
    public static ICommand? Accept(string input) => default;

    public Consequence Perform(Game game)
    {
        Console.WriteLine("Jeg forstod ikke hva du mente. Prøv igjen.");
        return Consequence.None;
    }
    public TimeSpan Duration => TimeSpan.Zero;
}
