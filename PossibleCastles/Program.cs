using PossibleCastles.Components;
using PossibleCastles.Entities;
using PossibleCastles.Systems;
using SDL2;
using PossibleCastles.UI;

namespace PossibleCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            SdlWindow window = new("Possible Castles", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED,
                1280, 960,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // TODO: get rid of magic numbers, put in a config file?
            SdlRenderer renderer = new(window.Win);
             
            SDL.SDL_RenderSetLogicalSize(renderer.Renderer, 640,
                480); // TODO: get rid of magic numbers, put in a config file?

            Hero player = new(10, 10);
            player.Name = "hero"; //TODO get this in constructor

            bool exit = false;
            InputSystem inputSystem = new();
            RenderSystem renderSystem = new(window, renderer.Renderer);
             
            // Main Loop
            while (true)
            {
                // Sets the color that the screen will be cleared with.
                SDL.SDL_SetRenderDrawColor(renderer.Renderer, 0, 0, 0, 255);

                // Clears the current render surface.
                SDL.SDL_RenderClear(renderer.Renderer);

                // This is where drawing happens
                inputSystem.Update();
                renderSystem.Update();
                 
                // Switches out the currently presented render surface with the one we just did work on.
                SDL.SDL_RenderPresent(renderer.Renderer);
            }
            renderer.Cleanup();
            window.Cleanup();
        }
    }
}