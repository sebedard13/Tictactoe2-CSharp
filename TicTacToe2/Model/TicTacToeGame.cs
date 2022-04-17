
using System.Collections.Generic;
using TicTacToe2.Controller.States;
using TicTacToe2.Model.Maps;
using TicTacToe2.Utils;
using TicTacToe2.Model.Players;
using TicTacToe2.View;

namespace TicTacToe2.Model
{
    public class TicTacToeGame
    {
        private readonly LoopList<Player> _playerTurn = new ();

        private readonly List<Player> _players;

        private readonly Map _map = new Map();

        private bool _gameIsActive = true;

        public TicTacToeGame(Player player1, Player player2)
        {
            _playerTurn.Enqueue(player1);
            _playerTurn.Enqueue(player2);
            _players = new List<Player> {player1, player2};
        }

        public void StartGame()
        {
            ViewController.Call("StartGame");
            ViewController.Call("UpdateMap", new[] {_map.GetStringRepresentation()});
            NextPlayerTurn();
        }

        private void EndGame()
        {
            Player playerWin = PlayerHasWin();
            if (playerWin == null && CalculateTie() || playerWin != null)
            {
                _gameIsActive = false;
            }
            ViewController.Call("UpdateMap", new []{_map.GetStringRepresentation()});

            if (!_gameIsActive)
            {
                if (playerWin == null)
                {
                    ViewController.Call("Tie");
                }
                else
                {
                    ViewController.Call("PlayerWin", new[] {playerWin.PlayerTile.ToString()});
                }
            }
        }

        public void CloseGame()
        {
            Program.CurrentState = new StatePlayerSelect(_players[0], _players[1]);
        }

        public bool PlayerTurn(int pos)
        {
            //Valid pos
            if (_map.GetCase(pos) == Tile.Empty)
            { 
                Player player = _playerTurn.LoopQueue();
                _map.SetCase(player.PlayerTile, pos);
                EndGame();
                return true;
            }

            return false;
        }

        public void NextPlayerTurn()
        {
            if (_gameIsActive)
            {
                _playerTurn.Peek().UserChoosePosition(this);
            }
        }

        private Player PlayerHasWin()
        {
            foreach (Player player in _players)
            {
                if (MapUtils.TileHasWin(player.PlayerTile,_map))
                {
                    return player;
                }
            }

            return null;
        }

        private bool CalculateTie()
        {
            return !_map.HasEmptyCase();
        }
        
    }
}