using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class NullCommand : ICommand
{
    public virtual void Execute(Entity entity) {}
}