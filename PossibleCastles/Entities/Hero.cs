using PossibleCastles.Components;
namespace PossibleCastles.Entities;

public class Hero : Entity
{
    public Hero(int x, int y)
    {
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(16, 24);
        AddComponent(dimension);
        
        RenderComponent render = new(location, dimension);
        AddComponent(render);

        InputComponent input = new(location);
        AddComponent(input);
    }
}