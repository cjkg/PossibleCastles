using PossibleCastles.Entity;

namespace PossibleCastles.UI.Input.Command;

public class MoveUpCommand : ICommand
{
    public virtual void Execute(Creature creature)
    {
        creature.Move(0, -1);
    } 
}