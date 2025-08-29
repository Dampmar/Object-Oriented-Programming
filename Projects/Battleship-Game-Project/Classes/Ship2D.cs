public class Ship2D : Ship
{
    private readonly int[,] _shape;

    // Constructor takes the starting point and the shape as a 2D array
    public Ship2D(int startRow, int startCol, int[,] shape)
        : base(startRow, startCol)
    {
        _shape = shape;
        Size = CalculateSize(shape); // Size is the number of cells the ship occupies
    }

    // Generate list of coordinates for a 2D ship based on its shape
    public override IEnumerable<(int row, int col)> GetCoordinates()
    {
        // Again same format as calculate size but returning the position of starting values plus an offset. 
        for (int i = 0; i < _shape.GetLength(0); i++)
        {
            for (int j = 0; j < _shape.GetLength(1); j++)
            {
                if (_shape[i, j] == 1)
                {
                    yield return (StartRow + i, StartCol + j);
                }
            }
        }
    }

    // Function in charge of calculating the occupied cells in the shape to get the num of ship parts 
    private int CalculateSize(int[,] shape)
    {
        // Goes through every value in the matrix and checks if it has a ship part or not
        int count = 0;
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
            {
                if (shape[i, j] == 1)
                {
                    count++;
                }
            }
        }
        return count;
    }
}