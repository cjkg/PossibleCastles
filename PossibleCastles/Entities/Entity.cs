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
}