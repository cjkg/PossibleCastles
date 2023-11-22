using PossibleCastles.Components;

namespace PossibleCastles.Entities;

public class Entity
{
    public Entity(int x, int y, string name)
    {
        X = x;
        Y = y;
        Name = name;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Name { get; set; }

    public List<Component> Components = new();

    public void AddComponent(Component component)
    {
        Components.Add(component);
        component.Entity = this;
    }

    public void RemoveComponent(Component component)
    {
        Components.Remove(component);
    }

    public bool HasComponent<T>() where T : Component
    {
        foreach (var c in Components)
            if (c is T)
                return true;

        return false;
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (var component in Components)
            if (component.GetType().Equals(typeof(T)))
                return (T)component;
        return null;
    }
}