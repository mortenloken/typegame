namespace TypeGame.Engine.Gameplay.Command;

/// <summary>
/// Represents the consequence of a command.
/// </summary>
/// <param name="quitGame"></param>
public class Consequence(bool quitGame)
{
    public static readonly Consequence None = new(false);
    public static readonly Consequence Quit = new(true);
    public static Consequence WithCommand(ICommand command) 
        => new(false, command);
    
    public bool QuitGame { get; } = quitGame;
    public ICommand? Command { get; }

    private Consequence(bool quitGame, ICommand command) : this(quitGame) 
        => Command = command;
}
