using System;
using System.Collections.Generic;
using Model.Players.PlayerStrategies;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Model.Maps;
using TicTacToe2.Utils;

namespace TicTacToe2.Model.Players
{
    public class MinMaxPlayer : PlayerStrategy
    {
        public override void UserChoosePosition(TicTacToeGame game)
        {
            MapContainer mapContainer = new MapContainer(game);
            int move = MinMax(mapContainer, mapContainer.CurrentPlayer(), 10, 0).move;
            game.PlayerTurn(move);
            game.NextPlayerTurn();
        }

        public MinMaxMove MinMax(MapContainer mapContainer, Player currentPlayer, int maxDepth, int currentDepth)
        {
            if(mapContainer.CurrentPlayer() == currentPlayer){
                String a = "d";
            }
            //    # Check if we’re done recursing.
            if (MapUtils.TileHasAnyWin(mapContainer.Map) || currentDepth == maxDepth)
            {
                MinMaxMove returnMoveEnd = new MinMaxMove();
                returnMoveEnd.move = -1;
                if (MapUtils.TileHasWin(currentPlayer.PlayerTile, mapContainer.Map))
                {
                    returnMoveEnd.score = 20;
                }
                else if(currentPlayer.PlayerTile == Tile.O && MapUtils.TileHasWin(Tile.X, mapContainer.Map) )
                {
                    returnMoveEnd.score = -20;
                }
                else if(currentPlayer.PlayerTile == Tile.X && MapUtils.TileHasWin(Tile.O, mapContainer.Map) )
                {
                    returnMoveEnd.score = -20;
                }
                else
                {
                    returnMoveEnd.score = 0;
                }

                return returnMoveEnd;
            }


            //  # Otherwise bubble up values from below.
            int bestMove = -1;
            int bestScore;
            if (mapContainer.CurrentPlayer() == currentPlayer)
            {
                bestScore= -9999;
            }
            else
            {
                bestScore = 9999;
            }
      
           
           
            // Go through each move.
            foreach (int move in mapContainer.GetMoves())
            {
              Map newMap= mapContainer.doMoveOn(move);

              MinMaxMove bestMoveOf = MinMax(new MapContainer(mapContainer,newMap), currentPlayer, maxDepth ,currentDepth + 1);

              if (mapContainer.CurrentPlayer() == currentPlayer)
              {
                  if (bestMoveOf.score > bestScore)
                  {
                      bestScore = bestMoveOf.score;
                      bestMove = move;
                  }
                  
              }
              else
              {
                  if (bestMoveOf.score < bestScore)
                  {
                      bestScore = bestMoveOf.score;
                      bestMove = move;
                  }
              }
            }

            MinMaxMove returnMove = new MinMaxMove();
            returnMove.move = bestMove;
            returnMove.score = bestScore;
            return returnMove;
        }
    }

    public struct MinMaxMove
    {
        public int move;
        public int score;
    }

    public class MapContainer
    {
        public Map Map;

        private LoopList<Player> _players = new ();

       public MapContainer(TicTacToeGame game)
        {
            Map = (Map) game.Map.Clone();
            Queue<Player>.Enumerator d = game.playersTurn.GetEnumerator();
            while (d.MoveNext()) {
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
            return  _players.Peek();
        }
        
        public List<int> GetMoves()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < Map.Size*Map.Size+1; i++)
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
            newmap.SetCase(_players.Peek().PlayerTile,move);
            return newmap;
        }
    }
}