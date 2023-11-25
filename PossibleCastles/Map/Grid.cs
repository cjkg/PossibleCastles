namespace PossibleCastles;

public class Grid
// Thanks to Jamis Buck for the idea behind this class
{
    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Grid = PrepareGrid();
        ConfigureCells();
    }
    
    public int Rows { get; set; }
    public int Columns { get; set; }

    public List<List<Cell>> PrepareGrid()
    {
        List<List<Cell>> Grid = new();
        Cell cell;
        for (int i = 0; i < Rows; i++)
        {
            List<Cell> row = new();
            for (int j = 0; j < Rows; j++)
            {
                cell = new Cell(i, j);
                row.Add(cell);
            }
            Grid.Add(row);
        }

        return Grid;
    }

    public void ConfigureCells()
    {
        
    }
}