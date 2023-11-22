namespace PossibleCastles.Components;

public class WalkableComponent : Component
{
    public WalkableComponent(bool walkable)
    {
        Walkable = walkable;
    }

    public bool Walkable { get; set; }
}