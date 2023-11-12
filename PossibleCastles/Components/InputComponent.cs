using PossibleCastles.Command;
using PossibleCastles.Systems;
using SDL2;

namespace PossibleCastles.Components;

public class InputComponent : Component
{
    public InputComponent(LocationComponent locationComponent)
    {
        Invoker entityInvoker = new(locationComponent);
        EntityInvoker = entityInvoker;
        InputSystem.Register(this);
    }
    public Invoker EntityInvoker { get; set; }

    public void Update()
    {
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
        {
            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                switch (e.key.keysym.sym) //TODO: make these swappable
                {
                    case SDL.SDL_Keycode.SDLK_w:
                        EntityInvoker.Press(new MoveUpCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_a:
                        EntityInvoker.Press(new MoveLeftCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_s:
                        EntityInvoker.Press(new MoveDownCommand());
                        break;
                    case SDL.SDL_Keycode.SDLK_d:
                        EntityInvoker.Press(new MoveRightCommand());
                        break;
                    default:
                        EntityInvoker.Press(new NullCommand());
                        break;
                }

                EntityInvoker.Command();
                break; //TODO: Is this right?
            }
        }
    }
}