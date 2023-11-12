using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles.Command;

public interface ICommand
{
    virtual void Execute(LocationComponent component) {}
}