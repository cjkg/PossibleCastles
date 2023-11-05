using PossibleCastles.Command;
using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class Entity
{

    public Entity(string name, int x, int y, int w, int h, IntPtr texture, List<Component> components)
    {
        Name = name;
        X = x;
        Y = y;
        W = w;
        H = h;
        Texture = texture;
        Components = components;
    }

    public List<Component> Components { get; set; }
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; } 
    public int W { get; set; }
    public int H { get; set; }
    public IntPtr Texture { get; set; }
    private InputComponent Input = new(); // TODO: put in list

    public bool Move(int dx, int dy)
    {
        if (CanMove(X + dx, Y + dy))
        {
            X += dx;
            Y += dy;
            return true;
        }

        return false;
    }

    public bool CanMove(int x, int y)
    {
        return true; // TODO put in real conditions
    }
    
    public void UpdateComponents()
    {
        Input.Update(new Invoker(this));
    }

    public void AddComponent(Component component)
    {
        Components.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        Components.Remove(component);
    }

    public void StartComponent(Component component)
    {
        
    }
}