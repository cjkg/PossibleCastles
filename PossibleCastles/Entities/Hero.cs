using PossibleCastles.Components;
namespace PossibleCastles.Entities;

public class Hero : Entity
{
    public Hero(int x, int y, string name) : base(x, y, name)
    {
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(1, 1);
        AddComponent(dimension);
        
        RenderComponent render = new(location, dimension);
        AddComponent(render);

        InputComponent input = new(location);
        AddComponent(input);

        MobileComponent mobile = new(input);
        AddComponent(mobile);
        
        CreatureComponent creature = new();
        AddComponent(creature);

    }
}