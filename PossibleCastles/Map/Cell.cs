using System.ComponentModel;

namespace PossibleCastles;

public class Cell
{
    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
        Dictionary<Cell, bool> Links = new();
    }

    public readonly int Row;
    public readonly int Column;
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
    
    
}