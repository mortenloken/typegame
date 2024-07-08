namespace TypeGame.Engine.Entity;

public class Player(string name, Inventory inventory) : Being
{
    public string Name { get; } = name;
    public Inventory Inventory { get; set; } = inventory;
}
