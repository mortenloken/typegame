using JetBrains.Annotations;

namespace TypeGame.Engine.Gameplay.Command;

public interface ICommand
{
    [UsedImplicitly]
    static abstract ICommand? Accept(string input);

    Consequence Execute(Game game);
}
