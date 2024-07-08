using JetBrains.Annotations;

namespace TypeGame.Engine.Gameplay.Command;

public interface ICommand
{
    [UsedImplicitly]
    static abstract ICommand? Accept(string input);
    Consequence Perform(Game game);
    TimeSpan Duration { get; }
}
