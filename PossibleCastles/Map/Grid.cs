namespace PossibleCastles;

public class Grid
// Thanks to Jamis Buck for the idea behind this class
{
    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Size = rows * columns;
        GridLayout = PrepareGrid();
        ConfigureCells();
    }
    
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int Size {get; set; }

    public List<List<Cell>> GridLayout { get; set; }
    
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
        foreach (List<Cell> row in GridLayout)
        {
            foreach (Cell cell in row)
            {
                int cellRow = cell.Row;
                int cellCol = cell.Column;

                cell.North = cellRow - 1 < 0 ? null : GridLayout[cellRow - 1][cellCol];
                cell.South = cellRow + 1 > Rows ? null : GridLayout[cellRow + 1][cellCol];
                cell.West = cellCol - 1 < 0 ? null : GridLayout[cellRow][cellCol - 1];
                cell.East = cellCol + 1 > Columns ? null : GridLayout[cellRow][cellCol + 1];
            }
        }
    }

    public Cell RandomCell()
    {
        Random rand = new();
        int row = rand.Next(0, Rows);
        int col = rand.Next(0, Columns);

        return GridLayout[row][col];
    }
}