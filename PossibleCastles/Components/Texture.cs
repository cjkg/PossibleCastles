

using SDL2;

namespace PossibleCastles.Components;

public class Texture : Component
{
    public Texture(IntPtr entityTexture, IntPtr renderer)
    {
        EntityTexture = entityTexture;
    }
    
    public IntPtr EntityTexture { get; set; }
    private IntPtr Renderer { get; set; } 
    
    public void Update()
    {
        SDL.SDL_Rect creatureSrcrect;
        SDL.SDL_Rect creatureDstrect;

        Dimension dimension = Entity.GetComponent<Dimension>();
        creatureSrcrect.x = 0;
        creatureSrcrect.y = 0;
        creatureSrcrect.w = dimension.W;
        creatureSrcrect.h = dimension.H;

        creatureDstrect.x = Entity.X * 16; // TODO: remove magic number, put in config file?
        creatureDstrect.y = Entity.Y * 24; // TODO: remove magic number, put in config file?
        creatureDstrect.w = dimension.W;
        creatureDstrect.h = dimension.H;

        SDL.SDL_RenderCopy(Renderer, EntityTexture, ref creatureSrcrect, ref creatureDstrect);
    }
}