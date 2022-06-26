using Model.Players.PlayerStrategies;

namespace TicTacToe2.Model.Players
{
    public class Player
    {
        private readonly Tile _playerTile;
        public PlayerStrategy strategy {get;set;}

        public Player(Tile playerTile)
        {
            _playerTile = playerTile;
        }

        public void UserChoosePosition(TicTacToeGame game){
            strategy.UserChoosePosition(game);
        }

        public Tile PlayerTile => _playerTile;
    }
}