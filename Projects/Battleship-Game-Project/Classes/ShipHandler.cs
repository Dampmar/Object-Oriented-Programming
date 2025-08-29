public class ShipHandler {
    public void InitializeShips(int numShips, Grid grid, List<Ship> ships)
    {
        Random rand = new Random();
        int shipsPlaced = 0;

        while (shipsPlaced < numShips)
        {
            int rand_row = rand.Next(0, grid.Size);
            int rand_col = rand.Next(0, grid.Size);
            bool is2D = shipsPlaced % 3 == 0; // For every 3 1D ships, generate a 2D ship
            Ship ship;

            // Generating a random ship instance 
            if (is2D)
                ship = GenerateRandom2DShip(rand_row, rand_col);
            else
                ship = GenerateRandom1DShip(rand_row, rand_col);

            if (ship.IsPlacementValid(grid))
            {
                grid.PlaceShip(ship);
                ships.Add(ship);
                shipsPlaced++;
            }
        }
    }
    private static Ship1D GenerateRandom1DShip(int startRow, int startCol) {
        Random rand = new Random();
        int length = rand.Next(2,6);
        int direction = rand.Next(0,2);
        return new Ship1D(length, startRow, startCol, direction);
    }
    private static Ship2D GenerateRandom2DShip(int startRow, int startCol)
    {
        Random rand = new Random();
        int[,] shape;

        // Define possible shapes
        switch (rand.Next(0, 4)) // Randomly choose one of the predefined shapes
        {
            case 0: // "T" Shape
                shape = new int[,]
                {
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                };
                break;
            case 1: // "L" Shape
                shape = new int[,]
                {{ 1, 0 },
                 { 1, 0 },
                 { 1, 1 }};
                break;
            case 2: // "+" Shape
                shape = new int[,]
                {
                    { 0, 1, 0 },
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                };
                break;
            case 3: // Another shape
                shape = new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 1 }
                };
                break;
            default:
                throw new ArgumentOutOfRangeException(); // Ensure valid shape
        }

        return new Ship2D(startRow, startCol, shape);
    }
}