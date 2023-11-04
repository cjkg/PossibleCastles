using PossibleCastles.Command;
using SDL2;
using PossibleCastles.Entity;
using PossibleCastles.UI;

namespace PossibleCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Creature> creatures = new();

            SdlWindow window = new("Possible Castles", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED,
                1280, 840,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN); // TODO: get rid of magic numbers, put in a config file?
            SdlRenderer renderer = new(window.Win);
            SDL.SDL_RenderSetLogicalSize(renderer.Renderer, 640,
                420); // TODO: get rid of magic numbers, put in a config file?

            string imagePath = "Textures/Creatures/hero.png";
            IntPtr heroImage = SDL_image.IMG_Load(imagePath);
            IntPtr heroTexture = SDL.SDL_CreateTextureFromSurface(renderer.Renderer, heroImage);

            imagePath = "Textures/Creatures/spider.png";
            IntPtr spiderImage = SDL_image.IMG_Load(imagePath);
            IntPtr spiderTexture = SDL.SDL_CreateTextureFromSurface(renderer.Renderer, spiderImage);

            Creature hero = new(20, 8, 16, 24, heroTexture, "Hero", 5, 10, 10);
            creatures.Add(hero);

            Creature spider = new(5, 5, 16, 24, spiderTexture, "Spider", 10, 3, 3);
            creatures.Add(spider);

            Creature spider2 = new(10, 10, 16, 24, spiderTexture, "Spider", 10, 3, 3);
            creatures.Add(spider2);

            bool exit = false;
            
            Invoker playerHandler = new(hero);
            
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
                        case SDL.SDL_EventType.SDL_KEYDOWN:

                            switch (e.key.keysym.sym)
                            {
                                case SDL.SDL_Keycode.SDLK_w:
                                    playerHandler.Press(new MoveUpCommand()); // TODO: Make movements into a flywheel instead of a command
                                    break;
                                case SDL.SDL_Keycode.SDLK_a:
                                    playerHandler.Press(new MoveLeftCommand()); // TODO: Make movements into a flywheel instead of a command
                                    break;
                                case SDL.SDL_Keycode.SDLK_s:
                                    playerHandler.Press(new MoveDownCommand()); // TODO: Make movements into a flywheel instead of a command
                                    break;
                                case SDL.SDL_Keycode.SDLK_d:
                                    playerHandler.Press(new MoveRightCommand()); // TODO: Make movements into a flywheel instead of a command
                                    break;
                                default:
                                    playerHandler.Press(new NullCommand());
                                    break;
                            }

                            playerHandler.Command();
                            break;
                    }
                }

                // Sets the color that the screen will be cleared with.
                SDL.SDL_SetRenderDrawColor(renderer.Renderer, 0, 0, 0, 255);

                // Clears the current render surface.
                SDL.SDL_RenderClear(renderer.Renderer);

                // This is where drawing happens
                renderer.RenderCreatures(creatures);

                // Switches out the currently presented render surface with the one we just did work on.
                SDL.SDL_RenderPresent(renderer.Renderer);
            }

            renderer.Cleanup();
            window.Cleanup();
        }
    }
}