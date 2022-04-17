using System;
using TicTacToe2.Model;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;

namespace TicTacToe2.Controller.States
{
    public class StatePlayerSelect : State
    {
        private Player[] Player { get; } = {null, null};

        public StatePlayerSelect(Player p1 = null, Player p2 = null)
        {
            
            Player[0] = p1;
            Player[1] = p2;
            
            ViewController.Call("ChoosePlayer");
            
            UserEvents.Listen("set", strings =>
            {
                int playerNo = Int32.Parse(strings[0]) - 1;
                Tile tile;
                if (playerNo == 0)
                {
                    tile = Tile.O;
                }
                else
                {
                    tile = Tile.X;
                }
                switch (strings[1])
                {
                    case "User":
                        Player[playerNo] = new UserPlayer(tile);
                        break;
                    case "Random":
                        Player[playerNo] = new RandomPlayer(tile);
                        break;
                    default:
                        Debug.Warning("Not Valid Player");
                        break;
                }
                
                
                
            });

            UserEvents.Listen("GameStart", strings =>
            {
                if (Player[0] != null&& Player[1] != null)
                {
                    Program.CurrentState = new StateGame(Player);
                }
                else
                {
                    Debug.Warning("Players are not initialized to start Game");
                }
            });
        }
    }
}