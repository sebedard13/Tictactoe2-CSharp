using Model.Players.PlayerStrategies;

namespace TicTacToe2.Model.Players
{
    public class Player
    {
        public Player(Tile playerTile)
        {
            PlayerTile = playerTile;
        }

        public PlayerStrategy strategy { get; set; }

        public Tile PlayerTile { get; }

        public void UserChoosePosition(TicTacToeGame game)
        {
            strategy.UserChoosePosition(game);
        }
    }
}