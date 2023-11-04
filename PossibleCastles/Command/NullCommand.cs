using PossibleCastles.Entity;

namespace PossibleCastles.Command;

public class NullCommand : ICommand
{
    public virtual void Execute(Creature creature) {}
}