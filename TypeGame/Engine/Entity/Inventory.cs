using TypeGame.Engine.Util;

namespace TypeGame.Engine.Entity;

public class Inventory(IEnumerable<InventoryItem> items)
{
    private readonly List<InventoryItem> _items = items.ToList();

    public Inventory() : this([]) {}

    public InventoryItem? Get(string item)
        => _items.FirstOrDefault(x => x.Item.Aliases.Contains(item, StringComparer.CurrentCultureIgnoreCase));

    public void TransferTo(Inventory target, Item item, int count)
    {
        //find the item in the source inventory
        var sourceItem = _items.FirstOrDefault(x => x.Item == item);
        if (sourceItem == default)
        {
            throw new ApplicationException("Item not found in source inventory");
        }

        //resolve how many to transfer
        var transfer = count <= sourceItem.Count 
            ? count 
            : sourceItem.Count;

        //deduct from source
        sourceItem.Count -= transfer;
        if (sourceItem.Count <= 0)
        {
            _items.Remove(sourceItem);
        }

        //add to target
        var targetItem = target._items.FirstOrDefault(x => x.Item == item);
        if(targetItem == default)
        {
            target._items.Add(new InventoryItem(item, transfer));
        }
        else
        {
            targetItem.Count += transfer;
        }
    }
    
    public override string ToString()
        => StringUtil.ListItems(_items.Select(x => $"{x.Count} {x.Item.Name.ToLower()}").ToArray());
}
