using PossibleCastles.Entity;

namespace PossibleCastles.Command;

public class Invoker
{
    private Creature _creature;
    private ICommand? _press;

    public Invoker(Creature creature)
    {
        _creature = creature;
    }

    public void Press(ICommand command)
    {
        this._press = command;
    }

    public void Command()
    {
        if (this._press is ICommand)
        {
            this._press.Execute(_creature);
        }
    }
}