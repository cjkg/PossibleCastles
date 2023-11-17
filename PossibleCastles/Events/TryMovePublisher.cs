using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Events;

public class TryMovePublisher
{
    public event EventHandler<TryMoveEventArgs> TryMoveUp;

    public void FireEvent(LocationComponent component, int dx, int dy)
    {
        OnTryMoveUp(new TryMoveEventArgs(component, dx, dy));
    }

    protected virtual void OnTryMoveUp(TryMoveEventArgs e)
    {
        EventHandler<TryMoveEventArgs> raiseEvent = TryMoveUp;

        if (raiseEvent != null)
        {
            raiseEvent(this, e);
        }
    }
}