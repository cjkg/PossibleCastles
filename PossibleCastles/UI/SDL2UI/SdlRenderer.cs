using SDL2;
using PossibleCastles.Entity;

namespace PossibleCastles.UI.SDL2UI;

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
       // TODO: need to get this out of main into here. 
    }
    
    public IntPtr Renderer { get; set; }
    
    public void Cleanup()
    {
        // Clean up the resources that were created.
        SDL.SDL_DestroyRenderer(Renderer);
    }
}