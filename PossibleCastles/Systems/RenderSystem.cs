using System.Net.Mime;
using PossibleCastles.Components;
using PossibleCastles.Entities;
using PossibleCastles.UI;
using SDL2;

namespace PossibleCastles.Systems;

public class RenderSystem
{
    private Dictionary<string, IntPtr> textures = new();
    protected static List<Component> Components = new();
    
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
            string textureType;
            switch (key)
            {
                case "spider":
                    textureType = "Creatures";
                    break;
                case "hero":
                    textureType = "Creatures";
                    break;
                default:
                    textureType = "Creatures";
                    break;
            }

            string filePath = "Textures/" + textureType + "/" + key + ".png";
            IntPtr image = SDL_image.IMG_Load(filePath);
            texture = SDL.SDL_CreateTextureFromSurface(Renderer, image);
            textures.Add(key, texture);
        }

        return texture;
    }

    public void Update()
    {
        foreach (RenderComponent c in Components)
        {
            c.Update(Renderer, TextureFactory(c.Entity.Name));
        }
    }

    public void Cleanup()
    {
        // Clean up the resources that were created.
        SDL.SDL_DestroyRenderer(Renderer);
    }
}