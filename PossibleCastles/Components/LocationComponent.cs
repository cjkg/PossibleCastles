using System.Data;

namespace PossibleCastles.Components;

public class LocationComponent : Component
{
    public LocationComponent(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public int X { get; set; }
    public int Y { get; set; }
    
    public void Update() {}
}