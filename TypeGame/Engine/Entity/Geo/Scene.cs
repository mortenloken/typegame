using TypeGame.Engine.Entity.Beings;
using TypeGame.Engine.Entity.Things;

namespace TypeGame.Engine.Entity.Geo;

public class Scene(
    string name,
    string[] aliases,
    string preposition,
    string description,
    Inventory initialInventory,
    Being[] initialBeings
)
{
    public string Name { get; } = name;
    public string[] Aliases { get; } = aliases;
    public string Description { get; } = description;
    public Inventory Inventory { get; } = initialInventory;
    public string Preposition { get; } = preposition;

    //the beings in the scene
    private readonly List<Being> _beings = initialBeings.ToList();

    //the scene links
    private readonly List<SceneLink> _links = [];
    
    #region Links methods and properties
    public void ConnectTo(Scene scene, int distance)
    {
        if (!IsConnectedTo(scene))
        {
            _links.Add(new SceneLink(this, scene, distance));
        }

        if (!scene.IsConnectedTo(this))
        {
            scene._links.Add(new SceneLink(scene, this, distance));
        }
    }
    
    public bool IsConnectedTo(Scene scene) 
        => _links.Any(x => x.To == scene);
    
    public IReadOnlyList<SceneLink> Links 
        => _links.AsReadOnly();
    #endregion
    
    #region Being methods and properties
    public bool Contains(Being being) => _beings.Contains(being);

    public void Add(Being being)
    {
        if (!_beings.Contains(being))
        {
            _beings.Add(being);
        }
    }

    public void Remove(Being being) 
        => _beings.Remove(being);
    #endregion
}
