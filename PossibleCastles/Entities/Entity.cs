using PossibleCastles.Components;
namespace PossibleCastles.Entities;

public class Entity
{
   public int Id { get; set; }
   public int X { get; set; }
   public int Y { get; set; }
   
   public List<Component> Components = new();

   public void AddComponent(Component component)
   { 
      Components.Add(component);
      component.Entity = this;
   }

   public T GetComponent<T>() where T : Component
   {
      foreach (Component component in Components)
      {
         if (component.GetType().Equals(typeof(T)))
         {
            return (T)component;
         }
      }

      return null;
   }
}