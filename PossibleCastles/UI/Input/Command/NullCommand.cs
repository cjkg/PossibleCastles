using PossibleCastles.Entity;
namespace PossibleCastles.UI.Input.Command;

public class NullCommand : ICommand
{
    public virtual void Execute(Creature creature) {}
}