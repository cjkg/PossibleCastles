﻿using SDL2;

namespace PossibleCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine($"There was an issue initializing SDL. {SDL.SDL_GetError()}");
            }

            var window = SDL.SDL_CreateWindow("Possible Castles", SDL.SDL_WINDOWPOS_UNDEFINED,
                SDL.SDL_WINDOWPOS_UNDEFINED, 720, 400, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            if (window == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
            }

            var renderer = SDL.SDL_CreateRenderer(window,
                -1,
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

            if (renderer == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");
            }

            string imagePath = "Images/hero.png"; 
            IntPtr image = SDL_image.IMG_Load(imagePath);
            IntPtr texture = SDL.SDL_CreateTextureFromSurface(renderer, image);

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
                if (SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255) < 0)
                {
                    Console.WriteLine($"There was an issue with setting the render draw color. {SDL.SDL_GetError()}");
                }
                
                // Clears the current render surface.
                if (SDL.SDL_RenderClear(renderer) < 0)
                {
                    Console.WriteLine($"There was an issue with clearing the render surface. {SDL.SDL_GetError()}");
                }
                
                // This is where drawing happens
                SDL.SDL_RenderCopy(renderer, texture, IntPtr.Zero, IntPtr.Zero);
                // Switches out the currently presented render surface with the one we just did work on.
                SDL.SDL_RenderPresent(renderer); 
            }
            
            // Clean up the resources that were created.
            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit(); 
        }
    }
}