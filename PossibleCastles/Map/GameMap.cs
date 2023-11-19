using PossibleCastles.Components;
using PossibleCastles.Entities;

namespace PossibleCastles;

public class GameMap
{
    public GameMap(int width, int height, int floor)
    {
        Width = width;
        Height = height;
        Level = floor;
    }

    public int Width { get; set; }
    public int Height { get; set; }
    public int Level { get; set; }
    public List<Entity> Tiles { get; set; }

    public void GenerateRandomTiles()
    {
        List<Entity> tiles = new();
        Random rand = new Random(); 
        
        for (int i = 0; i < (Width * Height); i++)
        {
            if (rand.Next(0, 2) < 0.5)
            {
                tiles.Add(new FloorBase(i % Width, i / Width,"floor_base"));
            }
            else
            {
                tiles.Add(new WallBase(i % Width, i / Width,"wall_stone"));
            }
        }
    }
}