using PossibleCastles.Entity;

namespace PossibleCastles.Command;

public class MoveRightCommand : ICommand
{
    public void Execute(Creature creature)
    {
        creature.Move(1, 0);
    } 
}
