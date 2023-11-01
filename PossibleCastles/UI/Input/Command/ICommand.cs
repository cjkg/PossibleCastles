using PossibleCastles.Entity;

namespace PossibleCastles.UI.Input.Command;

public interface ICommand
{
    virtual void Execute(Creature creature) {}
}