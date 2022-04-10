using TicTacToe2.Model;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;

namespace TicTacToe2
{
    internal static class Program
    {
        private static TicTacToeGame _game;
        
        private static void Main(string[] args)
        {
            Debug.Debuger = new DebugerAll();

            ConsoleInterface.WriteLine("Choose First player Tile O");
            Player player1 = GetFromView.Player(Tile.O);
            ConsoleInterface.WriteLine("Choose First player Tile O");
            Player player2 = GetFromView.Player(Tile.X);
            bool newGame = true;
            while (newGame)
            {
                _game = new TicTacToeGame(player1, player2);
                _game.StartGame();
                ConsoleInterface.WriteLine("Restart the game? y/n");
                newGame = GetFromView.Boolean();
            }
        }
    }
}