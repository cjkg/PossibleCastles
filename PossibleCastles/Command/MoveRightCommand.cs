using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class MoveRightCommand : ICommand
{
    public void Execute(LocationComponent component)
    {
        component.X += 1;
    } 
}
