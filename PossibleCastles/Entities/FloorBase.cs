using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class FloorBase : Entity 
{
    public FloorBase(int x, int y, string name) : base(x, y, name)
    {
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(1, 1);
        AddComponent(dimension);

        TextureComponent texture = new(name, "Tiles");
        AddComponent(texture);

        RenderComponent render = new(location, dimension, texture);
        AddComponent(render);

        WalkableComponent walkable = new(true);
        AddComponent(walkable);

        MapTileComponent mapTile = new();
        AddComponent(mapTile);
    } 
}