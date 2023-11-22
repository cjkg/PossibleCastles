using PossibleCastles.UI;

namespace PossibleCastles.Components;

public class TextureComponent : Component
{
   public TextureComponent(string name, string textureType)
   {
      Name = name;
      TextureType = textureType;
      Layer = SetLayer();
   } 
   
   public string Name { get; set; }
   static public string TextureType { get; set; }
   public int Layer { get; }
   
   static public int SetLayer()
   {
      int layer;
      switch (TextureType)
      {
         case "Creatures":
            layer = 0;
            break;
         case "Tiles":
            layer = 1;
            break;
         default:
            layer = 1;
            break;
      }

      return layer;
   }
}