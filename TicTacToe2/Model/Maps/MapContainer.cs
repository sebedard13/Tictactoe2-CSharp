using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe2.Model.Players;
using TicTacToe2.Utils;

namespace TicTacToe2.Model.Maps
{
    public class MapContainer
    {
        public Map Map;

        private LoopList<Player> _players = new();

        public MapContainer(TicTacToeGame game)
        {
            Map = (Map)game.Map.Clone();
            Queue<Player>.Enumerator d = game.playersTurn.GetEnumerator();
            while (d.MoveNext())
            {
                _players.Enqueue(d.Current);
            }

        }

        public MapContainer(MapContainer game, Map map)
        {
            Map = map;
            Queue<Player>.Enumerator d = game._players.GetEnumerator();
            while (d.MoveNext())
            {
                _players.Enqueue(d.Current);
            }
            _players.LoopQueue();
            Player p = _players.Peek();
            String a = "";

        }

        //For test
        public MapContainer(Map map, Player currentPlayer, Player nextPlayers)
        {
            Map = map;


            _players.Enqueue(currentPlayer);
            _players.Enqueue(nextPlayers);

        }

        public Player CurrentPlayer()
        {
            return _players.Peek();
        }

        public List<int> GetMoves()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < Map.Size * Map.Size + 1; i++)
            {
                if (Map.GetCase(i).Equals(Tile.Empty))
                {
                    list.Add(i);
                }
            }

            return list;
        }

        public Map doMoveOn(int move)
        {
            Map newmap = (Map)Map.Clone();
            newmap.SetCase(_players.Peek().PlayerTile, move);
            return newmap;
        }

        public int Evaluate(Player player)
        {
            if (MapUtils.TileHasWin(player.PlayerTile, Map))
            {
                return 200;
            }
            else if (player.PlayerTile == Tile.O && MapUtils.TileHasWin(Tile.X, Map))
            {
                return -200;
            }
            else if (player.PlayerTile == Tile.X && MapUtils.TileHasWin(Tile.O, Map))
            {
                return -200;
            }
            else
            {
                return 0;
            }
        }
    }
}
