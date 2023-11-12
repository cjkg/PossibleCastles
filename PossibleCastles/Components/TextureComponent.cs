using PossibleCastles.UI;

namespace PossibleCastles.Components;

public class TextureComponent
{
    public TextureComponent(IntPtr texture)
    {
        Texture = texture;
    }
    
    public IntPtr Texture { get; set; } 
    
    public void Update() {}
}