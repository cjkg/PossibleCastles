using PossibleCastles.Entities;

namespace PossibleCastles.Components;

public abstract class Component
{
    // Runs at game start
    public Entity Entity { get; set; }
    public virtual void Update() {}
}