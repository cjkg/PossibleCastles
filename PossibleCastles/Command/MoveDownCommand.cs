using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class MoveDownCommand : ICommand
{
    public virtual void Execute(Entity entity)
    {
        entity.Move(0, 1);
    }
}