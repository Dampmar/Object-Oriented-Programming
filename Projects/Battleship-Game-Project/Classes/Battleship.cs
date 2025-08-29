// Class in charge of deciding which game to play
using System.ComponentModel.DataAnnotations;

public abstract class BattleshipGame {
    protected int _GridSize;
    protected ShipHandler _ShipHandler;
    protected List<Ship> _Ships;
    private char[] _ValidLetters;
    
    public BattleshipGame(int grid_size) {
        _GridSize = grid_size;
        _ShipHandler = new ShipHandler();
        _Ships = new List<Ship>();
    }
    public abstract void Play();

    protected bool ValidateInput(string userInput, out int row, out int col){
        row = col = -1;
        // Checking if the use has given an invalid input in any way 
        if (userInput.Length < 2 || !char.IsLetter(userInput[0]) || !char.IsDigit(userInput[1]) ){
            return false;
        }
        // Performing operations to handle the user input as rows and columns of the grid
        col = userInput[0] - 'A';
        row = int.Parse(userInput[1].ToString());

        // Calling a method that is in charge of validating if true 
        return true;
    }
    
    protected void Fire (Grid grid, int Row, int Col) {
        if (grid.Cells[Row, Col] == 1)
        {
            Console.WriteLine("You've hit a ship!");
            grid.Cells[Row, Col] = 2; // Change value to hit
            grid.ShipParts--;
        }
        else
        {
            Console.WriteLine("Missed a shot.");
            grid.Cells[Row, Col] = 3; // Mark as miss
        }
        return;
    }

    protected int PlayTurn(Grid grid, ref int numAttempts){
        grid.PrintGrid();
        Console.Write("Make a guess (Example A1): "); 
        string userInput = Console.ReadLine().ToUpper();
        if (userInput == "EXIT") return 1;
        // Checking if the user input is valid
        if (ValidateInput(userInput, out int row, out int col) && grid.IsValidCoordinate(row, col)){
            Fire(grid, row, col);
            numAttempts++;
        } else {
            return -1;
        }
        return 0;
    }
}