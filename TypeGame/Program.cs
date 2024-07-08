using TypeGame.Engine.Entity;
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
var scenes = new Scene[] {
    new("Stua", ["stua", "stue", "stuen", "stuå"], "i", "Det er fint i stua.", new Inventory([new InventoryItem(nok, 50)]), []),
    new("Kjøkkenet", ["kjøkkenet", "kjøkken"], "på", "Det er rotete på kjøkkenet.", new Inventory(), [player])
};

//start game
var game = new Game(
    player, 
    scenes, 
    DateTime.Today.AddHours(8)
);
game.Play();
