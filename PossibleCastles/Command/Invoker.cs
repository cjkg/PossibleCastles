using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class Invoker
{
    private LocationComponent _component;
    private ICommand? _press;

    public Invoker(LocationComponent component)
    {
        _component = component;
    }

    public void Press(ICommand command)
    {
        this._press = command;
    }

    public void Command()
    {
        if (this._press is ICommand)
        {
            this._press.Execute(_component);
        }
    }
}