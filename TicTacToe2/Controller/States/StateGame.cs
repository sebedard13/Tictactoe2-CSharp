using TicTacToe2.Controller.Event.EventList;
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

            UserEvents.Listen<Play>( args =>
            {
                bool valid = game.PlayerTurn(args.Position);
                if (!valid)
                    Debug.Warning("Not valid Case");
                else
                    game.NextPlayerTurn();
            });

            UserEvents.Listen("closegame", strings => { game.CloseGame(); });
        }
    }
}