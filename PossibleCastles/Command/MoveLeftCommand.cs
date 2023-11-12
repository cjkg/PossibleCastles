using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class MoveLeftCommand : ICommand
{
    public void Execute(LocationComponent component)
    {
        component.X -= 1;
    } 
}