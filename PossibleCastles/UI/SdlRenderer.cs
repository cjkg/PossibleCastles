using PossibleCastles.Components;
using PossibleCastles.Entities;
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

    /*
    public void RenderEntities(List<Entity> entities)
    {
        foreach (Entity entity in entities)
        {
            SDL.SDL_Rect creatureSrcrect;
            SDL.SDL_Rect creatureDstrect;

            Dimension dimension = entity.GetComponent<Dimension>();
            creatureSrcrect.x = 0;
            creatureSrcrect.y = 0;
            creatureSrcrect.w = dimension.W;
            creatureSrcrect.h = dimension.H;

            creatureDstrect.x = entity.X * 16; // TODO: remove magic number, put in config file?
            creatureDstrect.y = entity.Y * 24; // TODO: remove magic number, put in config file?
            creatureDstrect.w = dimension.W;
            creatureDstrect.h = dimension.H;

            SDL.SDL_RenderCopy(Renderer, EntityTexture, ref creatureSrcrect, ref creatureDstrect);
        }
        // TODO: need to get this out of main into here.
    }
    */

    public IntPtr Renderer { get; set; }
    private static Dictionary<string, IntPtr> textures = new();

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

            var filePath = "Textures/" + textureType + "/" + key + ".png";
            var image = SDL_image.IMG_Load(filePath);
            texture = SDL.SDL_CreateTextureFromSurface(Renderer, image);
            textures.Add(key, texture);
        }

        return texture;
    }

    public void Cleanup()
    {
        // Clean up the resources that were created.
        SDL.SDL_DestroyRenderer(Renderer);
    }
}