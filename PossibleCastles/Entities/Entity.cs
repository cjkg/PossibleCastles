using PossibleCastles.Components;
namespace PossibleCastles.Entities;

public class Entity
{
   public int Id { get; set; }
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