namespace TypeGame.Engine.Entity.Things;

public class InventoryItem(Item item, int count)
{
    public Item Item { get; } = item;
    public int Count { get; set; } = count;
}
