namespace PossibleCastles.Components;

public class PhysicsComponent : Component
{
    public PhysicsComponent(int hp, bool solid)
    {
        Hp = hp;
        Solid = solid;
    }
    
    public int Hp { get; set; }
    public bool Solid { get; set; }
}