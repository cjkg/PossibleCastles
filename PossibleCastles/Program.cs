using SDL2;
using PossibleCastles.UI.SDL2UI;
using PossibleCastles.Entity;

namespace PossibleCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            SdlWindow window = new("Possible Castles", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, 960,
                720, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            
            SDL.SDL_RenderSetLogicalSize(window.Renderer, 640, 480);
            
            string imagePath = "Textures/Creatures/hero.png"; 
            IntPtr heroImage = SDL_image.IMG_Load(imagePath);
            IntPtr heroTexture = SDL.SDL_CreateTextureFromSurface(window.Renderer, heroImage);
            Creature hero = new(0, 0, 16, 24, heroTexture, "Hero", 5, 10, 10);
            SDL.SDL_Rect heroSrcrect;
            SDL.SDL_Rect heroDstrect;
            
            heroSrcrect.x = 0;
            heroSrcrect.y = 0;
            heroSrcrect.w = hero.W;
            heroSrcrect.h = hero.H;
            
            heroDstrect.x = hero.X*16;
            heroDstrect.y = hero.Y*24;
            heroDstrect.w = hero.W;
            heroDstrect.h = hero.H;

            bool exit = false;
            
            // Main Loop
            while (!exit)
            {
                // Event and continue to do so until the queue is empty.
                while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
                {
                    switch (e.type)
                    {
                        case SDL.SDL_EventType.SDL_QUIT:
                            exit = true;
                            break;
                    }
                }
                
                // Sets the color that the screen will be cleared with.
                if (SDL.SDL_SetRenderDrawColor(window.Renderer, 0, 0, 0, 255) < 0)
                {
                    Console.WriteLine($"There was an issue with setting the render draw color. {SDL.SDL_GetError()}");
                }
                
                // Clears the current render surface.
                if (SDL.SDL_RenderClear(window.Renderer) < 0)
                {
                    Console.WriteLine($"There was an issue with clearing the render surface. {SDL.SDL_GetError()}");
                }

                // This is where drawing happens
                SDL.SDL_RenderCopy(window.Renderer, heroTexture, ref heroSrcrect, ref heroDstrect);

                // Switches out the currently presented render surface with the one we just did work on.
                SDL.SDL_RenderPresent(window.Renderer); 
            }
            window.Cleanup();
        }
    }
}