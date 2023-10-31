using System.ComponentModel;
using System.Runtime.CompilerServices;
using SDL2;

namespace PossibleCastles.UI.SDL2UI;

public class SdlWindow
{
    public SdlWindow(string title, int x, int y, int width, int height, SDL.SDL_WindowFlags flags)
    {
        Title = title;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Flags = flags;
        Win = SDL.SDL_CreateWindow(Title, X, Y, Width, Height, Flags);
        Renderer = SDL.SDL_CreateRenderer(Win,
          -1,
          SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
          SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC); // TODO: Abstract away flags
 
    }
    
    public string Title { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public SDL.SDL_WindowFlags Flags { get; set; } 
    public IntPtr Win { get; set; }
    public IntPtr Renderer { get; set; }
    
    public void Cleanup()
    {
        // Clean up the resources that were created.
        SDL.SDL_DestroyRenderer(Renderer);
        SDL.SDL_DestroyWindow(Win);
        SDL.SDL_Quit();
    }
}