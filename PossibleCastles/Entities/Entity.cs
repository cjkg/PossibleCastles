namespace PossibleCastles.Entities;

public class Entity
{
    public Entity(int x, int y, int w, int h, IntPtr texture, string name)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
        Texture = texture;
        Name = name;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public int W { get; set; }
    public int H { get; set; }
    public IntPtr Texture { get; set; }
    public string Name { get; set; }

    public bool Move(int dx, int dy)
    {
        if (CanMove(X + dx, Y + dy))
        {
            X += dx;
            Y += dy;
            return true;
        }

        return false;
    }

    public bool CanMove(int x, int y)
    {
        return true; // TODO put in real conditions
    }
}