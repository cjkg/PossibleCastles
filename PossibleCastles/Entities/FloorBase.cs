using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class FloorBase : Entity
{
   public FloorBase(int x, int y)
   {
        LocationComponent location = new(x, y);
        AddComponent(location);

        DimensionComponent dimension = new(16, 24);
        AddComponent(dimension);

        RenderComponent render = new(location, dimension);
        AddComponent(render);

        PhysicsComponent physics = new(10, false);
        AddComponent(physics);
   } 
}