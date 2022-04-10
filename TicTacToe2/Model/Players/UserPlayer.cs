using System;
using TicTacToe2.View;

namespace TicTacToe2.Model.Players
{
    public class UserPlayer : Player
    {
        public override int UserChoosePosition()
        {
            Console.WriteLine("Choose position");
           

            return GetFromView.Integer(1,10);
        }

        public UserPlayer(Tile playerTile) : base(playerTile)
        {
            
        }
    }
}