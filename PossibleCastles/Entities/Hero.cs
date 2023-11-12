using PossibleCastles.Components;
namespace PossibleCastles.Entities;

public class Hero : Entity
{
    public Hero(int x, int y, IntPtr texture)
    {
        Texture = texture;
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(16, 24);
        AddComponent(dimension);
        
        RenderComponent render = new(location, dimension);
        AddComponent(render);
    }
    
    public IntPtr Texture { get; set; }
}
