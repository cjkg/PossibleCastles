using PossibleCastles.Events;

namespace PossibleCastles.Components;

public class MobileComponent : Component
{
    public MobileComponent(InputComponent input)
    {
        input.TryMovePub.TryMoveUp += HandleTryMove;
    }

    void HandleTryMove(object sender, TryMoveEventArgs e)
    {
        // TODO if not walkable, do nothing
        e.LocationComp.X += e.Dx;
        e.LocationComp.Y += e.Dy;
    } 
}