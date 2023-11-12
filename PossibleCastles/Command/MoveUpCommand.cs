using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class MoveUpCommand : ICommand
{
    public virtual void Execute(LocationComponent component)
    {
        component.Y -= 1;
    } 
}