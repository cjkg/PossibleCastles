using PossibleCastles.Entities;
using PossibleCastles.Systems;
using SDL2;
using PossibleCastles.UI;

namespace PossibleCastles;

internal class Program
{
    private static void Main(string[] args)
    {
        SdlWindow window = new("Possible Castles", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED,
            1280, 960,
            SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // TODO: get rid of magic numbers, put in a config file?
        SdlRenderer renderer = new(window.Win);

        SDL.SDL_RenderSetLogicalSize(renderer.Renderer, 640,
            480); // TODO: get rid of magic numbers, put in a config file?

        Hero player = new(10, 10, "hero");

        var exit = false;

        InputSystem inputSystem = new();
        RenderSystem renderSystem = new(window, renderer.Renderer);
        GameMap map = new(80, 50, 1);
        map.GenerateBinaryTreeTiles();
        // Main Loop
        while (true)
        {
            var start = SDL.SDL_GetPerformanceCounter();

            inputSystem.Update();

            // Sets the color that the screen will be cleared with.
            SDL.SDL_SetRenderDrawColor(renderer.Renderer, 0, 0, 0, 255);

            // Clears the current render surface.
            SDL.SDL_RenderClear(renderer.Renderer);

            // This is where drawing happens
            renderSystem.Update();

            var end = SDL.SDL_GetPerformanceCounter();

            var elapsedMS = (end - start) / SDL.SDL_GetPerformanceFrequency() * 1000.0f;

            // Switches out the currently presented render surface with the one we just did work on.
            SDL.SDL_RenderPresent(renderer.Renderer);
            
            // Maxes at 60 FPS, probably overkill
            var frameTime = SDL.SDL_GetTicks();
            SDL.SDL_Delay((uint)Math.Floor(16.666f - elapsedMS));
        }

        renderSystem.Cleanup();
        window.Cleanup();
    }
}