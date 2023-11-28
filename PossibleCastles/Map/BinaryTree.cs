namespace PossibleCastles;

public class BinaryTree
// Thanks to Jamis Buck for the ideas behind this class
{
    public static Grid On(Grid grid)
    {
        Random rnd = new Random();
        foreach (List<Cell> row in grid.GridLayout)
        {
            foreach (Cell cell in row)
            {
                List<Cell> neighbors = new();
                if (cell.North != null) neighbors.Add(cell.North);
                if (cell.East != null) neighbors.Add(cell.East);

                int index = rnd.Next(0, neighbors.Count);
                Cell neighbor = neighbors[index];

                if (neighbor != null) cell.Link(neighbor);
            }
        }

        return grid;
    }
}