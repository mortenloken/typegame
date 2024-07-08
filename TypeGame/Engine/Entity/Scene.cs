namespace TypeGame.Engine.Entity;

public class Scene(
    string name,
    string[] aliases,
    string preposition,
    string description, 
    Inventory inventory,
    Being[] beings
) {
    public string Name { get; } = name;
    public string[] Aliases { get; } = aliases;
    public string Description { get; } = description;
    public Inventory Inventory { get; } = inventory;
    public string Preposition { get; } = preposition;

    //the beings in the scene
    private readonly List<Being> _beings = beings.ToList();
    
    #region Being methods and properties
    public bool Contains(Being being) => _beings.Contains(being);

    public void Add(Being being) {
        if (!_beings.Contains(being)) {
            _beings.Add(being);
        }
    }
    
    public void Remove(Being being) {
        _beings.Remove(being);
    }
    #endregion
}
