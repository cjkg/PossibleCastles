using SDL2;

namespace PossibleCastles.Map;

public class Tile
{
    public required char Character { get; set; }
    public required int Color { get; set; } // TODO: change to short?
    public required int DarkColor { get; set; }
    public required bool Walkable { get; set; }
    public required bool BlocksSight { get; set; }

    public void Render(SDL.SDL_Rect camera)
    {
    }
}