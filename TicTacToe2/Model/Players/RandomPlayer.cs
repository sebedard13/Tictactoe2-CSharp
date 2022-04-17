using System;

namespace TicTacToe2.Model.Players
{
    public class RandomPlayer : Player
    {
        public RandomPlayer(Tile playerTile) : base(playerTile)
        {
        }

        public override void UserChoosePosition(TicTacToeGame game)
        {
            Random rnd = new Random();

            game.PlayerTurn(rnd.Next(1, 10));
            game.NextPlayerTurn();
        }
    }
}