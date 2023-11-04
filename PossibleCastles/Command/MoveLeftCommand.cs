using PossibleCastles.Entity;

namespace PossibleCastles.Command;

public class MoveLeftCommand : ICommand
{
    public void Execute(Creature creature)
    {
        creature.Move(-1, 0);
    } 
}