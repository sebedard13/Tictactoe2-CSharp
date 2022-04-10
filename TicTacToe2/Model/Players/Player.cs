namespace TicTacToe2.Model.Players
{
    public abstract class Player
    {
        private readonly Tile _playerTile;

        protected Player(Tile playerTile)
        {
            _playerTile = playerTile;
        }

        public abstract int UserChoosePosition();

        public Tile PlayerTile => _playerTile;
    }
}