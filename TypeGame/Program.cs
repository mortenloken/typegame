using TypeGame.Engine.Entity.Beings;
using TypeGame.Engine.Entity.Geo;
using TypeGame.Engine.Entity.Things;
using TypeGame.Engine.Gameplay;

var nok = new Item("Kr", ["kr", "pengene"]);
var underwear = new Item("Truse", ["truse", "trusa", "trusen", "underbuksa"]);

//setup
var player = new Player(
    "Mathias",
    new Inventory(
    [
        new InventoryItem(nok, 100),
        new InventoryItem(underwear, 1)
    ])
);

//create scenes
var stua = new Scene("Stua", ["stua", "stue", "stuen", "stuå"], "i", "Det er fint i stua.", new Inventory([new InventoryItem(nok, 50)]), []);
var kjøkkenet = new Scene("Kjøkkenet", ["kjøkkenet", "kjøkken"], "på", "Det er rotete på kjøkkenet.", new Inventory(), [player]);
var terrassen = new Scene("Terrassen", ["terrassen", "terrasse"], "på", "Det er vått på terrassen.", new Inventory(), []);

//connect scenes
stua.ConnectTo(kjøkkenet, 10);
kjøkkenet.ConnectTo(terrassen, 5);

var scenes = new[] {
    stua,
    kjøkkenet,
    terrassen
};

//start game
var game = new Game(
    player, 
    scenes, 
    DateTime.Today.AddHours(8)
);
game.Play();
