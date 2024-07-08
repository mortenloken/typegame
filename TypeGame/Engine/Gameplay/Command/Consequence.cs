namespace TypeGame.Engine.Gameplay.Command;

public class Consequence
{
    public static readonly Consequence None = new()
    {
        Duration = TimeSpan.Zero,
        QuitGame = false,
        Command = null
    };
    
    public static Consequence Durate(TimeSpan duration) => new()
    {
        Duration = duration,
        QuitGame = false,
        Command = null
    };
    
    public static readonly Consequence Quit = new()
    {
        Duration = TimeSpan.Zero,
        QuitGame = true,
        Command = null
    };
    
    public TimeSpan Duration { get; init; } = TimeSpan.Zero;
    public bool QuitGame { get; init; }
    public ICommand? Command { get; init; }
}
