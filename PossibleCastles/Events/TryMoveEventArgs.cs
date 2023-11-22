using PossibleCastles.Components;

namespace PossibleCastles.Events;

public class TryMoveEventArgs : EventArgs
{
    public readonly LocationComponent LocationComp;
    public readonly int Dx;
    public readonly int Dy;

    public TryMoveEventArgs(LocationComponent component, int dx, int dy)
    {
        LocationComp = component;
        Dx = dx;
        Dy = dy;
    }
}