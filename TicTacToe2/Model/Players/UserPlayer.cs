using TicTacToe2.View;

namespace TicTacToe2.Model.Players
{
    public class UserPlayer : Player
    {
        public UserPlayer(Tile playerTile) : base(playerTile)
        {
            
        }

        public override void UserChoosePosition(TicTacToeGame game)
        {
            //Wait For EventArgs
        }
    }
}