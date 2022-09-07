using System.Collections.Generic;
using TicTacToe2.Controller.States;
using TicTacToe2.Model.Maps;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils;
using TicTacToe2.View;

namespace TicTacToe2.Model
{
    public class TicTacToeGame
    {
        public readonly Map Map = new();

        private readonly List<Player> _players;
        public readonly LoopList<Player> playersTurn = new();

        private bool _gameIsActive = true;

        public TicTacToeGame(Player player1, Player player2)
        {
            playersTurn.Enqueue(player1);
            playersTurn.Enqueue(player2);
            _players = new List<Player> {player1, player2};
        }

        public void StartGame()
        {
            ViewController.Call("startgame");
            ViewController.Call("updatemap", new[] {Map.GetStringRepresentation()});
            NextPlayerTurn();
        }

        private void EndGame()
        {
            Player playerWin = PlayerHasWin();
            if (playerWin == null && CalculateTie() || playerWin != null) _gameIsActive = false;
            ViewController.Call("updatemap", new[] {Map.GetStringRepresentation()});

            if (!_gameIsActive)
            {
                if (playerWin == null)
                    ViewController.Call("tie");
                else
                    ViewController.Call("playerwin", new[] {playerWin.PlayerTile.ToString()});
            }
        }

        public void CloseGame()
        {
            Program.CurrentState = new StatePlayerSelect(_players[0], _players[1]);
        }

        public bool PlayerTurn(int pos)
        {
            //Valid Position
            if (Map.GetCase(pos) == Tile.Empty && pos>0 && pos < Map.Size*Map.Size+1)
            {
                Player player = playersTurn.LoopQueue();
                Map.SetCase(player.PlayerTile, pos);
                EndGame();
                return true;
            }

            return false;
        }

        public void NextPlayerTurn()
        {
            if (_gameIsActive) playersTurn.Peek().UserChoosePosition(this);
        }

        private Player PlayerHasWin()
        {
            foreach (Player player in _players)
                if (MapUtils.TileHasWin(player.PlayerTile, Map))
                    return player;

            return null;
        }

        private bool CalculateTie()
        {
            return !Map.HasEmptyCase();
        }
    }
}