using System.Reflection;
using TypeGame.Engine.Gameplay.Command.Commands;

namespace TypeGame.Engine.Gameplay.Command;

/// <summary>
/// Parses the input string into a command.
/// </summary>
public static class CommandParser {
    private static readonly List<Type> CommandTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => 
            t.IsAssignableTo(typeof(ICommand)) 
            && !t.IsAbstract
            && t != typeof(NotUnderstood) //ignore this "system" command
        )
        .ToList();
    
    public static ICommand Parse(string input)
    {
        //return the first command that accepts the input
        foreach (var commandType in CommandTypes)
        {
            if (commandType.GetMethod("Accept")?.Invoke(null, [input.ToLower()]) is ICommand command)
            {
                return command;
            }
        }
        return new NotUnderstood();
    }    
}
