public class Grid {
    public int Size {get; private set;}
    public int[,] Cells {get; private set;}
    public int ShipParts {get; set; }

    public Grid(int size){
        Size = size;
        Cells = new int[Size, Size];
        InitializeGrid();
        ShipParts = 0;
    }

    // Setting all grid values to zero
    private void InitializeGrid(){
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                Cells[i,j] = 0;
    }

    // Method in charge of placing the ship
    public void PlaceShip(Ship ship){
        foreach (var (row, col) in ship.GetCoordinates()){
            Cells[row, col] = 1;
            ShipParts++;
        }
    }

    // Method in charge of validating if the inputs are in the ranges of the grid
    public bool IsValidCoordinate(int row, int col){
        if (row >= 0 && row < Size && col >= 0 && col < Size) {
            bool notShootYet = !((Cells[row, col] == 3) || Cells[row, col] == 2);
            return notShootYet;
        } else {
            return false;
        }
    }

    // Function in charge of printing the Grid's cells
    public void PrintGrid()
    {
        Console.Write("\t ");
        for (int i = 0; i < Size; i++)
        {
            Console.Write(ConvertToLetter(i) + "\t");
        }
        Console.WriteLine();
        for (int i = 0; i < Size; i++)
        {
            Console.Write(i + "\t|");
            for (int j = 0; j < Size; j++)
            {
                if (Cells[i, j] == 0)
                {
                    Console.Write(" \t"); // Water
                }
                else if (Cells[i, j] == 1)
                {
                    Console.Write(" \t"); // Ship part (hidden from the player)
                }
                else if (Cells[i, j] == 2)
                {
                    Console.Write("X\t"); // Hit
                }
                else
                {
                    Console.Write("*\t"); // Miss
                }
            }
            Console.WriteLine();
        }
    }

    // For Both Players to play with the same boards 
    public void CopyGrid(Grid source){
        for (int row = 0; row < source.Size; row++)
        {
            for (int col = 0; col < source.Size; col++)
            {
                Cells[row, col] = source.Cells[row, col];
            }
        }

        // Copy the ShipParts value
        ShipParts = source.ShipParts;
    }

    private static char ConvertToLetter(int index)
    {
        return (char)('A' + index);
    }
}