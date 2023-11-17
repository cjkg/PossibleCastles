using PossibleCastles.Events;
using PossibleCastles.Systems;
using SDL2;

namespace PossibleCastles.Components;

public class InputComponent : Component
{
    public InputComponent(LocationComponent locationComponent)
    {
        LocationComp = locationComponent;
        InputSystem.Register(this);
        TryMovePublisher tryMovePub = new();
        TryMovePub = tryMovePub; // TODO: how to do this more idiomatically?
    }

    public LocationComponent LocationComp { get; private set; }

    public TryMovePublisher TryMovePub { get; set; }
    public void Update()
    {
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
        {
            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                switch (e.key.keysym.sym) //TODO: make these swappable
                {
                    case SDL.SDL_Keycode.SDLK_w:
                        TryMovePub.FireEvent(LocationComp, 0, -1); 
                        break;
                    case SDL.SDL_Keycode.SDLK_a:
                        TryMovePub.FireEvent(LocationComp, -1, 0);
                        break;
                    case SDL.SDL_Keycode.SDLK_s:
                        TryMovePub.FireEvent(LocationComp, 0, 1);
                        break;
                    case SDL.SDL_Keycode.SDLK_d:
                        TryMovePub.FireEvent(LocationComp, 1, 0);
                        break;
                }
                break; //TODO: Is this right?
            }
        }
    }
}