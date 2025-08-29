
public abstract class Ship
{
    public int Size { get; protected set; }
    public int StartRow { get; protected set; }
    public int StartCol { get; protected set; }

    public Ship(int startRow, int startCol)
    {
        StartRow = startRow;
        StartCol = startCol;
    }

    // Abstract method for getting coordinates, to be implemented by subclasses
    public abstract IEnumerable<(int row, int col)> GetCoordinates();

    // Check if the ship placement is valid
    public bool IsPlacementValid(Grid grid)
    {
        foreach (var (row, col) in GetCoordinates())
        {
            if (!grid.IsValidCoordinate(row, col) || grid.Cells[row, col] != 0)
            {
                return false;
            }
        }
        return true;
    }
}
