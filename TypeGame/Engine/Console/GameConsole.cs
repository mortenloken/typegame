using Spectre.Console;

namespace TypeGame.Engine.Console;

public static class GameConsole
{
    public static void Clear() 
        => AnsiConsole.Clear();

    public static void Blank() 
        => AnsiConsole.WriteLine();

    public static void Error(string s) 
        => AnsiConsole.MarkupLine($"[red]{s}[/]");

    public static void Confirm(string s) 
        => AnsiConsole.MarkupLine($"[green]{s}[/]");

    public static void Info(string s) 
        => AnsiConsole.MarkupLine($"[blue]{s}[/]");

    public static void PreAsk(string s) 
        => AnsiConsole.MarkupLine($"[yellow]{s}[/]");

    public static void Figlet(string s) 
        => AnsiConsole.Write(new FigletText(s).LeftJustified().Color(Color.Blue));

    public static string Ask(string s) => AnsiConsole.Ask<string>($"[yellow]{s}[/]");
}
