using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public interface ICommand
{
    virtual void Execute(Entity entity) {}
}