using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public class Invoker
{
    private Entity _entity;
    private ICommand? _press;

    public Invoker(Entity entity)
    {
        _entity = entity;
    }

    public void Press(ICommand command)
    {
        this._press = command;
    }

    public void Command()
    {
        if (this._press is ICommand)
        {
            this._press.Execute(_entity);
        }
    }
}