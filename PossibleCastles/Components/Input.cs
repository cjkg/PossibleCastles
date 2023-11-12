using PossibleCastles.Entities;
using SDL2;

namespace PossibleCastles.Components;

public class Input : Component
{
    /*public void Update(Entity entity)
    {
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
        {
            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                switch (e.key.keysym.sym)
                {
                    case SDL.SDL_Keycode.SDLK_w:
                        entityInvoker.Press(new MoveRightCommand()); 
                        break;
                    case SDL.SDL_Keycode.SDLK_a:
                        entityInvoker.Press(new MoveLeftCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_s:
                        entityInvoker.Press(new MoveDownCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_d:
                        entityInvoker.Press(new MoveRightCommand());
                        break;
                    default:
                        entityInvoker.Press(new NullCommand());
                        break;
                }
                entityInvoker.Command();
                break; //TODO: Is this right?
            }
        }
        
    }*/
    /*
    public void Update(Invoker entityInvoker)
    {
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
        {
            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                switch (e.key.keysym.sym)
                {
                    case SDL.SDL_Keycode.SDLK_w:
                        entityInvoker.Press(new MoveUpCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_a:
                        entityInvoker.Press(new MoveLeftCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_s:
                        entityInvoker.Press(new MoveDownCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_d:
                        entityInvoker.Press(new MoveRightCommand());
                        break;
                    default:
                        entityInvoker.Press(new NullCommand());
                        break;
                }
                entityInvoker.Command();
                break; //TODO: Is this right?
            }
        }
    }*/
}