using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class MoveLeftCommand : ICommand
{
    public void Execute(Entity entity)
    {
        entity.Move(-1, 0);
    } 
}