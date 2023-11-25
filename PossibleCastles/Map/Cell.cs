using System.ComponentModel;

namespace PossibleCastles;

public class Cell
// Thanks to Jamis Buck for the idea behind this class
{
    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
        Dictionary<Cell, bool> Links = new();
    }

    public readonly int Row;
    public readonly int Column;
    public Cell? North { get; set; }
    public Cell? East { get; set; }
    public Cell? South { get; set; }
    public Cell? West { get; set; }
    
    private Dictionary<Cell, bool> Links { get; set; }

    public Cell Link(Cell cell, bool bidi = true)
    {
        Links.Add(cell, true);
        if (bidi) cell.Link(this, false);
        return this;
    }

    public Cell Unlink(Cell cell, bool bidi = true)
    {
        Links.Remove(cell);
        if (bidi) cell.Unlink(this, false);
        return this;
    }

    public List<Cell> linksKeys()
    {
        return Links.Keys.ToList();
    }

    public bool IsLinked(Cell cell)
    {
        return linksKeys().Contains(cell);
    }

    public List<Cell> Neighbors()
    {
        List<Cell> neighbors = new();
        if (North != null) neighbors.Add(North);
        if (East != null) neighbors.Add(East);
        if (South != null) neighbors.Add(South);
        if (West != null) neighbors.Add(West);
        return neighbors;
    }
}