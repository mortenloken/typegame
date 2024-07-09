using TypeGame.Engine.Entity.Things;

namespace TypeGame.Engine.Entity.Beings;

public class Player(string name, Inventory inventory) : Being
{
    public string Name { get; } = name;
    public Inventory Inventory { get; } = inventory;
}
