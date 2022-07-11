using System.Collections.Generic;

namespace TicTacToe2.Model.Maps
{
    public static class MapUtils
    {
        public static bool TileHasWin(Tile playerTile, Map map)
        {
            for (int x = 0; x < map.Size; x++)
            for (int y = 0; y < map.Size; y++)
            {
                if (map.GetCase(x, y) != playerTile) break;

                if (y == map.Size - 1) return true;
            }

            for (int y = 0; y < map.Size; y++)
            for (int x = 0; x < map.Size; x++)
            {
                if (map.GetCase(x, y) != playerTile) break;

                if (x == map.Size - 1) return true;
            }

            {
                int xCross = 0;
                int yCross = 0;
                do
                {
                    if (map.GetCase(xCross, yCross) != playerTile) break;

                    if (xCross == map.Size - 1 && yCross == map.Size - 1) return true;

                    xCross++;
                    yCross++;
                } while (xCross < map.Size && yCross < map.Size);
            }
            {
                int xCross = 0;
                int yCross = map.Size - 1;
                do
                {
                    if (map.GetCase(xCross, yCross) != playerTile) break;

                    if (xCross == map.Size - 1 && yCross == 0) return true;

                    xCross++;
                    yCross--;
                } while (xCross < map.Size && yCross >= 0);
            }
            return false;
        }
        
        public static bool TileHasAnyWin(Map map)
        {
            return TileHasWin(Tile.O, map) || TileHasWin(Tile.X, map) || !map.HasEmptyCase();
        }
    }
}