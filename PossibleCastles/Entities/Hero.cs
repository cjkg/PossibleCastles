using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class Hero : Entity
{
    public Hero(int x, int y)
    {
        Dimension dimension = new(16, 24);
        AddComponent(dimension);
        Input input = new();
        AddComponent(input);
    }
}