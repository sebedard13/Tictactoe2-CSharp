using System;
using Model.Players.PlayerStrategies;

namespace TicTacToe2.Model.Players
{
    public class RandomPlayer : PlayerStrategy
    {
        public override void UserChoosePosition(TicTacToeGame game)
        {
            Random rnd = new Random();

            game.PlayerTurn(rnd.Next(1, 10));
            game.NextPlayerTurn();
        }
    }
}