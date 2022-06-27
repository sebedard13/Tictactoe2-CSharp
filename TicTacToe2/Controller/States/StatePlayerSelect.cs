using Model.Players.PlayerStrategies;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Model;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;

namespace TicTacToe2.Controller.States
{
    public class StatePlayerSelect : State
    {
        public StatePlayerSelect(Player p1 = null, Player p2 = null)
        {
            Player[0] = p1;
            Player[1] = p2;

            ViewController.Call("chooseplayer");

            UserEvents.Listen<SetPlayer>(args =>
            {
                Tile tile;
                if (args.playerNo == 0)
                    tile = Tile.O;
                else
                    tile = Tile.X;
                Player tmpPlayer = new(tile);
                tmpPlayer.strategy = StrategiesUtils.GetPlayerStrategy(args.playerStrategie);

                Player[args.playerNo] = tmpPlayer;
            });

            UserEvents.Listen("startgame", strings =>
            {
                if (Player[0] != null && Player[1] != null)
                    Program.CurrentState = new StateGame(Player);
                else
                    Debug.Warning("Players are not initialized to start Game");
            });
        }

        private Player[] Player { get; } = {null, null};
    }
}