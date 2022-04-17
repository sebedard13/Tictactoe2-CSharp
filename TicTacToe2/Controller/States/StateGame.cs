using System;
using TicTacToe2.Model;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils.Debug;

namespace TicTacToe2.Controller.States
{
    public class StateGame : State
    {
        public StateGame(Player[] players)
        {
            TicTacToeGame game = new TicTacToeGame(players[0], players[1]);
            game.StartGame();
            
            UserEvents.Listen("Play", strings =>
            {
                bool valid = game.PlayerTurn(Int16.Parse(strings[0]));
                if (!valid)
                {
                    Debug.Warning("Not valid Case");
                }
                else
                {
                    game.NextPlayerTurn();
                }
            });
            
            UserEvents.Listen("CloseGame", strings =>
            {
                game.CloseGame();
            });
        }
    }
}