using System;
using System.Collections.Generic;
using Model.Players.PlayerStrategies;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Model.Maps;
using TicTacToe2.Utils;
using TicTacToe2.Utils.Debug;

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

            //    # Check if we’re done recursing.
            if (MapUtils.TileHasAnyWin(mapContainer.Map) || currentDepth == maxDepth)
            {
                MinMaxMove returnMoveEnd = new MinMaxMove();
                returnMoveEnd.move = -1;
                returnMoveEnd.score = mapContainer.Evaluate(currentPlayer) / (currentDepth + 1);


                return returnMoveEnd;
            }


            //  # Otherwise bubble up values from below.
            int bestMove = -1;
            int bestScore;
            if (mapContainer.CurrentPlayer() == currentPlayer)
            {
                bestScore = -9999;
            }
            else
            {
                bestScore = 9999;
            }



            // Go through each move.
            foreach (int move in mapContainer.GetMoves())
            {
                Map newMap = mapContainer.doMoveOn(move);


                MinMaxMove bestMoveOf = MinMax(new MapContainer(mapContainer, newMap), currentPlayer, maxDepth, currentDepth + 1);

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
}