using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        int gridSize = 3;
        int numShips = 1;

        Console.Write("Which version do you want to play (PvP or PvC) > ");
        string userInput = Console.ReadLine().ToLower();
        BattleshipGame game = null;
        // allow the user to select the version they want to play
        if (userInput == "pvp")
            game = new PlayerVsPlayer(gridSize, numShips); 
        else if (userInput == "pvc")
            game = new PlayerVsComp(gridSize, numShips);
        
        // Play the game accordingly
        if (game == null){
            Console.WriteLine($"'{userInput}' is not a valid name game version.\nTerminating execution.");
            return;
        }
        else 
            game.Play();
    }
}
