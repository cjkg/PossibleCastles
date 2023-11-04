using PossibleCastles.Entity;

namespace PossibleCastles.Command;

public class MoveDownCommand : ICommand
{
    public virtual void Execute(Creature creature)
    {
        creature.Move(0, 1);
    }
}