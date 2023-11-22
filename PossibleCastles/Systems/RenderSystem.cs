using PossibleCastles.Components;
using PossibleCastles.Entities;
using PossibleCastles.UI;
using SDL2;

namespace PossibleCastles.Systems;

public class RenderSystem
{
    private Dictionary<string, IntPtr> textures = new();
    protected static List<RenderComponent> Components = new();
    
    public RenderSystem(SdlWindow window, IntPtr renderer)
    {
        Renderer = renderer;
    }

    public static void Register(RenderComponent component)
    {
        Components.Add(component);
    }
    
    public IntPtr Renderer { get; set; }

    public IntPtr TextureFactory(string key)
    {
        IntPtr texture;

        if (textures.ContainsKey(key))
        {
            texture = textures[key];
        }
        else
        {
            string filePath = "Textures/" + TextureType(key) + "/" + key + ".png";
            IntPtr image = SDL_image.IMG_Load(filePath);
            texture = SDL.SDL_CreateTextureFromSurface(Renderer, image);
            textures.Add(key, texture);
        }

        return texture;
    }

    public string TextureType(string key)
    {
        string textureType;
        switch (key)
        {
            case "hero":
            case "spider":
                textureType = "Creatures";
                break;
            case "floor_base":
            case "wall_stone":
                textureType = "Tiles";
                break;
            default:
                textureType = "Creatures";
                break;
        }

        return textureType;
    }

    public void Update()
    {
        Components.Sort((y, x) => x.Texture.Layer.CompareTo(y.Texture.Layer));
        foreach (RenderComponent c in Components)
        {
            // TODO: only if they are visible or explored. Maybe do a sort first?
            c.Update(Renderer, TextureFactory(c.Entity.Name));
        }
    }

    public void Cleanup()
    {
        // Clean up the resources that were created.
        SDL.SDL_DestroyRenderer(Renderer);
    }
}