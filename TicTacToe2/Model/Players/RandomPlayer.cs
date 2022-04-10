using System;
using TicTacToe2.Model.Players;

namespace TicTacToe2.Model.Players
{

    class RandomPlayer : Player
    {
        public RandomPlayer(Tile playerTile) : base(playerTile)
        {
        }

        public override int UserChoosePosition()
        {
            Random rnd = new Random();
            return rnd.Next(1, 10);
        }
    }
}