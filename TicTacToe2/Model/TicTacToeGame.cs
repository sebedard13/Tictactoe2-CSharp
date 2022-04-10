
using System.Collections.Generic;
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
            ConsoleInterface.WriteLine("Game Start");
            ConsoleInterface.WriteLine(_map.GetStringRepresentation());
            Player playerWin = null;
            while (_gameIsActive)
            {
                APlayerTurn();
                playerWin = PlayerHasWin();
                if (playerWin == null && CalculateTie() || playerWin != null)
                {
                    _gameIsActive = false;
                }
                ConsoleInterface.WriteLine(_map.GetStringRepresentation());
            }

            if (playerWin == null)
            {
                ConsoleInterface.WriteLine("It is a tie");
            }
            else
            {
                ConsoleInterface.WriteLine("Player "+playerWin.PlayerTile+" win");
            }
        }

        public void APlayerTurn()
        {
            Player player = _playerTurn.LoopQueue();
            bool validPos = true;
            do
            {
                int pos = player.UserChoosePosition();
                if (_map.GetCase(pos) == Tile.Empty)
                {
                    _map.SetCase(player.PlayerTile, pos);
                    validPos = false;
                }
                
            } while (validPos);
        }

        public Player PlayerHasWin()
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
        
        public bool CalculateTie()
        {
            return !_map.HasEmptyCase();
        }
        
    }
}