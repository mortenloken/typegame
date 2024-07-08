using System.Collections.ObjectModel;
using System.Diagnostics;
using TypeGame.Engine.Entity;
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

        //the main game loop
        while (true) {
            //parse the input to create a command
            var command = presentScene
                ? new Peek(true)
                : CommandParser.Parse(Console.ReadLine() ?? string.Empty);
            presentScene = false;

            //clear the console
            Console.Clear();
    
            //add the time spend of the command
            _timeSpends.Add(command.Duration);

            //perform the command
            var consequence = command.Perform(this);
            if (consequence.QuitGame)
            {
                //exit main game loop
                break;
            }

            //cascading consequences
            while (consequence.Command is not null)
            {
                _timeSpends.Add(consequence.Command.Duration);
                consequence = consequence.Command.Perform(this);
            }
            
            Console.WriteLine($"Klokka er {GetGameTime():HH:mm}.");
            Console.WriteLine();
            Console.Write("?? ");
        }
    }
    #endregion
}
