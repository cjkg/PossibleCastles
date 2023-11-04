using PossibleCastles.Command;
using PossibleCastles.Entities;
using PossibleCastles.UI;
using SDL2;

namespace PossibleCastles;

public class Engine
{
    public Engine(List<Entity> entities, Invoker eventHandler, Entity player)
    {
        Entities = entities;
        PlayerHandler = eventHandler;
        Player = player;
    }

    public List<Entity> Entities { get; set; }
    public Invoker PlayerHandler { get; set; }
    public Entity Player { get; set; }

    public bool HandleEvents()
    {
        
        // Event and continue to do so until the queue is empty.
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    return true; 
                case SDL.SDL_EventType.SDL_KEYDOWN:

                    switch (e.key.keysym.sym)
                    {
                        case SDL.SDL_Keycode.SDLK_w:
                            PlayerHandler.Press(new MoveUpCommand()); // TODO: Make movements into a flywheel instead of a command
                            break;
                        case SDL.SDL_Keycode.SDLK_a:
                            PlayerHandler.Press(new MoveLeftCommand()); // TODO: Make movements into a flywheel instead of a command
                            break;
                        case SDL.SDL_Keycode.SDLK_s:
                            PlayerHandler.Press(new MoveDownCommand()); // TODO: Make movements into a flywheel instead of a command
                            break;
                        case SDL.SDL_Keycode.SDLK_d:
                            PlayerHandler.Press(new MoveRightCommand()); // TODO: Make movements into a flywheel instead of a command
                            break;
                        default:
                            PlayerHandler.Press(new NullCommand());
                            break;
                    }

                    PlayerHandler.Command();
                    break;
            }
        }
        return false;
    }

    public void Render(SdlRenderer renderer)
    {
       //TODO: Get this out of main and into here 
    }
}