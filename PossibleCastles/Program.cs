﻿using PossibleCastles.Components;
using PossibleCastles.Entities;
using SDL2;
using PossibleCastles.UI;

namespace PossibleCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entity> entities = new();
            SdlWindow window = new("Possible Castles", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED,
                1280, 960,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // TODO: get rid of magic numbers, put in a config file?
            SdlRenderer renderer = new(window.Win);
            
            SDL.SDL_RenderSetLogicalSize(renderer.Renderer, 640,
                480); // TODO: get rid of magic numbers, put in a config file?

            Entity player = new("hero", 0, 5, 16, 24, renderer.TextureFactory("hero"), new List<Component>());
            entities.Add(player);/*
            Entity spider = new("spider", 0, 5, 16, 24, renderer.TextureFactory("spider"));
            entities.Add(spider);
            Entity spider2 = new("spider", 0, 10, 16, 24, renderer.TextureFactory("spider"));
            entities.Add(spider2);*/



            bool exit = false;
            
            // Main Loop
            while (true)
            {
                player.UpdateComponents();
                // Sets the color that the screen will be cleared with.
                SDL.SDL_SetRenderDrawColor(renderer.Renderer, 0, 0, 0, 255);

                // Clears the current render surface.
                SDL.SDL_RenderClear(renderer.Renderer);

                // This is where drawing happens
                renderer.RenderEntities(entities);

                // Switches out the currently presented render surface with the one we just did work on.
                SDL.SDL_RenderPresent(renderer.Renderer);
            }

            renderer.Cleanup();
            window.Cleanup();
        }
    }
}