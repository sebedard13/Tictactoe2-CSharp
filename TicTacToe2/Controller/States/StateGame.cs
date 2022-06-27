using TicTacToe2.Model;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils.Debug;

namespace TicTacToe2.Controller.States
{
    public class StateGame : State
    {
        public StateGame(Player[] players)
        {
            TicTacToeGame game = new(players[0], players[1]);
            game.StartGame();

            UserEvents.Listen("play", stringArgs =>
            {
                string[] strings = stringArgs.Args;
                bool valid = game.PlayerTurn(short.Parse(strings[0]));
                if (!valid)
                    Debug.Warning("Not valid Case");
                else
                    game.NextPlayerTurn();
            });

            UserEvents.Listen("closegame", strings => { game.CloseGame(); });
        }
    }
}