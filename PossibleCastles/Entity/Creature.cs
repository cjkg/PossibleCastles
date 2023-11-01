using SDL2;

namespace PossibleCastles.Entity;

public class Creature
{
    public Creature(int x, int y, int w, int h, IntPtr texture, string name, int fov, int hp, int maxHp)
    {
        X = x;
        Y = y;
        W = w;
        H = h;
        Texture = texture;
        Name = name;
        Fov = fov;
        Hp = hp;
        MaxHp = maxHp;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public int W { get; set; }
    public int H { get; set; }
    public IntPtr Texture { get; set; }
    public string Name { get; set; }
    public int Fov { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }

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

    public bool MoveDown()
    {
        if (CanMove(X, Y - 1))
        {
            Y += 1;
            return true;
        }

        return false;
    }
    public bool CanMove(int x, int y)
    {
        return true; // TODO put in real conditions
    }
}

// TODO: Move method

// TODO: CanMove method