using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class MoveDownCommand : ICommand
{
    public virtual void Execute(LocationComponent component)
    {
        component.Y += 1;
    }
}