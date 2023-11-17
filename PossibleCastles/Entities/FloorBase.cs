using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class FloorBase : Entity
{
    public FloorBase(int x, int y, string name) : base(x, y, name)
    {
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(16, 24);
        AddComponent(dimension);

        RenderComponent render = new(location, dimension);
        AddComponent(render);

        WalkableComponent walkable = new(true);
        AddComponent(walkable);
    } 
}