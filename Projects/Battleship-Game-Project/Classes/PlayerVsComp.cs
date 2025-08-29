using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

public class PlayerVsComp : BattleshipGame {
    private int _NumAttempts;
    private Grid _Grid;
    private int _AmountOfPieces;
    public PlayerVsComp(int grid_size, int num_ships) : base(grid_size) {
        _NumAttempts = 0;
        _Grid = new Grid(_GridSize);
        _ShipHandler.InitializeShips(num_ships, _Grid, _Ships);
    }

    public override void Play()
    {   
        Console.WriteLine("Playing the Single Player Version.");
        Console.WriteLine("> Make guesses such as A1, where A stands for Column and 1 stands for row");
        Console.WriteLine("> The game ends when the user manages to destroy all ship parts.");
        Console.WriteLine("> If the player wants to exit write 'exit' as a guess.");
        _AmountOfPieces = _Grid.ShipParts;
        int TurnMessage = 0;
        while (_Grid.ShipParts > 0)
        {
            TurnMessage = PlayTurn(_Grid, ref _NumAttempts);
            if (TurnMessage == 1) {
                Console.WriteLine("Exiting game, goodbye!");
                return;
            }
        }
        _Grid.PrintGrid();
        // Game Winning Results 
        Console.WriteLine("\t|Game Over|");
        if (_NumAttempts <= _AmountOfPieces + _AmountOfPieces/2)
            Console.WriteLine("\nYou're record is hard to beat. Pretty lucky, I must admit!\n");
        Console.WriteLine($"You've sunk all ships in {_NumAttempts} attempts.\n");
    }
}