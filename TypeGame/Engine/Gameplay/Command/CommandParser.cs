using System.Reflection;

namespace TypeGame.Engine.Gameplay.Command;

public static class CommandParser {
    private static readonly List<Type> CommandTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => 
            t.IsAssignableTo(typeof(ICommand)) 
            && !t.IsAbstract
            && t != typeof(NotUnderstood) //ignore this "system" action
        )
        .ToList();
    
    public static ICommand Parse(string input)
    {
        //return the first actions that accepts the input
        foreach (var commandType in CommandTypes)
        {
            if (commandType.GetMethod("Accept")?.Invoke(null, [input.ToLower()]) is ICommand action)
            {
                return action;
            }
        }
        return new NotUnderstood();
    }    
}
