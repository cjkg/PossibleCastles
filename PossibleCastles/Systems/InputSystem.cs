using System.Data;
using PossibleCastles.Components;

namespace PossibleCastles.Systems;

public class InputSystem
{
    protected static List<Component> Components = new();
    
    public static void Register(InputComponent component)
    {
        Components.Add(component);
    }

    public void Update()
    {
        foreach (InputComponent c in Components)
        {
            c.Update();
        }
    }
}