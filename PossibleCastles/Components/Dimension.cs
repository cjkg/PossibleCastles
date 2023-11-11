using System.Data;

namespace PossibleCastles.Components;

public class Dimension : Component
{
    public Dimension(int w, int h)
    {
        W = w;
        H = h;
    }
    
    public int W { get; set; }
    public int H { get; set; }

    public void Update()
    {
        
    }
}