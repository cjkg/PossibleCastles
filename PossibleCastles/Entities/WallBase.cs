using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class WallBase : Entity
{
    public WallBase(int x, int y, string name) : base(x, y, name)
    {
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(1, 1);
        AddComponent(dimension);

        TextureComponent texture = new("wall", "Tiles");
        AddComponent(texture);

        RenderComponent render = new(location, dimension, texture);
        AddComponent(render);

        WalkableComponent walkable = new(false);
        AddComponent(walkable);

        MapTileComponent mapTile = new();
        AddComponent(mapTile);
    }
}