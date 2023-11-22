namespace PossibleCastles.Components;

public class DimensionComponent : Component
{
    public DimensionComponent(int w, int h)
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