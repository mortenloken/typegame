using TypeGame.Engine.Util;

namespace TypeGame.Engine.Entity;

public class Inventory(IEnumerable<InventoryItem> items)
{
    private readonly List<InventoryItem> _items = items.ToList();

    public Inventory() : this([]) {}

    public InventoryItem? Get(string item)
        => _items.FirstOrDefault(x => x.Item.Aliases.Contains(item, StringComparer.CurrentCultureIgnoreCase));
    
    public void Add(Item item, int count)
    {
        var exists = _items.FirstOrDefault(x => x.Item == item);
        if (exists != default)
        {
            exists.Count += count;
        }
        else
        {
            _items.Add(new InventoryItem(item, count));
        }
    }
    
    public void Remove(Item item, int count)
    {
        var exists = _items.FirstOrDefault(x => x.Item == item);
        if (exists != default)
        {
            exists.Count -= count;
            if (exists.Count <= 0)
            {
                _items.Remove(exists);
            }
        }
    }

    
    public override string ToString()
        => StringUtil.ListItems(_items.Select(x => $"{x.Count} {x.Item.Name.ToLower()}").ToArray());
}
