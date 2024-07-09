using System.Collections.ObjectModel;
using System.Diagnostics;
using TypeGame.Engine.Console;
using TypeGame.Engine.Entity.Beings;
using TypeGame.Engine.Entity.Geo;
using TypeGame.Engine.Gameplay.Command;
using TypeGame.Engine.Gameplay.Command.Commands;

namespace TypeGame.Engine.Gameplay;

public class Game(Player player, IEnumerable<Scene> scenes, DateTime baseTime) {
    //time
    private readonly Stopwatch _stopWatch = Stopwatch.StartNew();
    private readonly List<TimeSpan> _timeSpends = [TimeSpan.Zero];
    
    //the collection of all scenes
    private IReadOnlyCollection<Scene> Scenes { get; } = new ReadOnlyCollection<Scene>(scenes.ToList());

    #region Public methods and properties
    public Player Player { get; } = player;
    public Scene GetCurrentScene()
        => Scenes.SingleOrDefault(x => x.Contains(Player)) 
           ?? throw new InvalidOperationException("Player is not in any scene");

    public Scene? GetScene(string scene)
        => Scenes.SingleOrDefault(x => x.Aliases.Contains(scene, StringComparer.CurrentCultureIgnoreCase));

    private DateTime GetGameTime()
        => baseTime //the start of the game
           + _stopWatch.Elapsed // actual time spent playing the game
           + _timeSpends.Aggregate((a, b) => a + b); //time spent on commands
    #endregion
    
    #region Main game loop
    public void Play() {
        //initialize
        var presentScene = true;

        GameConsole.Figlet("Typegame!");
        GameConsole.Blank();
        GameConsole.Info("Velkommen til Typegame!");
        GameConsole.Info("Trykk en tast for å starte spillet!");
        System.Console.ReadLine();
        
        //the main game loop
        while (true) {
            //parse the input to create a command
            var command = presentScene
                ? new Peek(true)
                : CommandParser.Parse(GameConsole.Ask("?"));
            presentScene = false;

            //clear the console
            GameConsole.Clear();
    

            //perform the command
            var consequence = command.Execute(this);

            //add the time spend of the command
            _timeSpends.Add(consequence.Duration);
            
            if (consequence.QuitGame)
            {
                //exit main game loop
                break;
            }

            //cascading consequences
            while (consequence.Command is not null)
            {
                consequence = consequence.Command.Execute(this);
                _timeSpends.Add(consequence.Duration);
            }
            
            GameConsole.Blank();
            GameConsole.PreAsk($"Klokka er {GetGameTime():HH:mm:ss}.");
        }
    }
    #endregion
}
