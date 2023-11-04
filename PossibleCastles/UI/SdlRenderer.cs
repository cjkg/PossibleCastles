using PossibleCastles.Entity;
using SDL2;

namespace PossibleCastles.UI;

public class SdlRenderer
{
    public SdlRenderer(IntPtr Window)
    {
        Renderer = SDL.SDL_CreateRenderer(Window,
            -1,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
            SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC); // TODO: Abstract away flags
 
    }

    public void RenderCreatures(List<Creature> creatures)
    {
        foreach (Creature creature in creatures)
        {
            SDL.SDL_Rect creatureSrcrect;
            SDL.SDL_Rect creatureDstrect;

            creatureSrcrect.x = 0;
            creatureSrcrect.y = 0;
            creatureSrcrect.w = creature.W;
            creatureSrcrect.h = creature.H;

            creatureDstrect.x = creature.X * 16; // TODO: remove magic number, put in config file?
            creatureDstrect.y = creature.Y * 24; // TODO: remove magic number, put in config file?
            creatureDstrect.w = creature.W;
            creatureDstrect.h = creature.H;

            SDL.SDL_RenderCopy(Renderer, creature.Texture, ref creatureSrcrect, ref creatureDstrect);
        }
        // TODO: need to get this out of main into here. 
    }
    
    public IntPtr Renderer { get; set; }
    
    public void Cleanup()
    {
        // Clean up the resources that were created.
        SDL.SDL_DestroyRenderer(Renderer);
    }
}