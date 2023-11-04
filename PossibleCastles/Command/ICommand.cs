using PossibleCastles.Entity;

namespace PossibleCastles.Command;

public interface ICommand
{
    virtual void Execute(Creature creature) {}
}