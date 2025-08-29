using System.Runtime.CompilerServices;

public class PlayerVsPlayer : BattleshipGame {
    private Grid _GridP1;
    private Grid _GridP2;
    private int _NumAttemptsP1;
    private int _NumAttemptsP2;
    private string _P1Name;
    private string _P2Name;

    // Both players will be playing on the same grid, first one to destroy all Ship Parts in less attempts win 
    public PlayerVsPlayer(int grid_size, int num_ships) : base(grid_size) {
        _NumAttemptsP1 = 0;
        _NumAttemptsP2 = 0; 
        _GridP1 = new Grid(_GridSize);
        _ShipHandler.InitializeShips(num_ships, _GridP1, _Ships);
        _GridP2 = new Grid(_GridSize);
        // _GridP2.CopyGrid(_GridP1);
        _ShipHandler.InitializeShips(num_ships, _GridP2, _Ships);
    }

    public override void Play()
    {   
        // Write a description
        Console.WriteLine("Playing the Two Player Version.");
        Console.WriteLine("> Make guesses such as A1, where A stands for Column and 1 stands for row");
        Console.WriteLine("> Make sure the guesses are in the range displayed on your screen.");
        Console.WriteLine("> The game ends when one of the users or both manages to destroy all ship parts.");
        Console.WriteLine("> If a player wants to exit write 'exit' as a guess.");
        Console.WriteLine("> Please take turns.");
        SetPlayerNames();
        bool isPlayer1Turn = true;
        int TurnMessage = 0;
        // Whoever shoots first has the advantage of surprise 
        while (_GridP1.ShipParts > 0 && _GridP2.ShipParts > 0)
        {   
            // Player One Turn
            if (isPlayer1Turn){
                Console.WriteLine($"\t{_P1Name}'s turn");
                TurnMessage = PlayTurn(_GridP1, ref _NumAttemptsP1);
            } else {
                Console.WriteLine($"\t{_P2Name}'s turn");
                TurnMessage = PlayTurn(_GridP2, ref _NumAttemptsP2);
            }
            // Checking if a player has left 
            if (TurnMessage == 1) {
                Console.WriteLine("Exiting game, Goodbye!");
                return;
            }
            else if (TurnMessage == -1){
                Console.WriteLine("Invalid bullet placement, Try Again!");
                continue;
            }
            isPlayer1Turn = !isPlayer1Turn;
        }
        Console.WriteLine("\t|Game Over|");
        if (_GridP1.ShipParts < _GridP2.ShipParts) {
            Console.WriteLine($"{_P1Name} wins in {_NumAttemptsP1} attempts!");
        } else if (_GridP2.ShipParts < _GridP1.ShipParts) {
            Console.WriteLine($"{_P2Name} wins in {_NumAttemptsP2} attempts!");
        }
    }

    private void SetPlayerNames(){
        Console.Write("Enter Player 1's name: ");
        _P1Name = Console.ReadLine();
        Console.Write("Enter Player 2's name: ");
        _P2Name = Console.ReadLine();
    }
} 