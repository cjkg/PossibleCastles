using PossibleCastles.Systems;
using SDL2;

namespace PossibleCastles.Components;

public class RenderComponent: Component
{
    public RenderComponent(LocationComponent locationComponent, DimensionComponent dimensionComponent)
    {
        Location = locationComponent;
        Dimension = dimensionComponent;
        RenderSystem.Register(this);
    }
    
    public LocationComponent Location { get; set; }
    public DimensionComponent Dimension { get; set; }
    
    public void Update()
    {
        //Put this sucker in a draw function, where the renderer can be easily passed to it.
        SDL.SDL_Rect RenderableSrcRect = new();
        SDL.SDL_Rect RenderableDstRect = new();
        
        RenderableSrcRect.x = 0;
        RenderableSrcRect.y = 0;
        RenderableSrcRect.w = Dimension.W;
        RenderableSrcRect.h = Dimension.H;

        RenderableDstRect.x = Location.X * 16; // TODO: remove magic number, put in config file?
        RenderableDstRect.y = Location.Y * 24; // TODO: remove magic number, put in config file?
        RenderableDstRect.w = Dimension.W;
        RenderableDstRect.h = Dimension.H;
        
        
    }
}