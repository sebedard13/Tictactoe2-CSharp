using System;
using TicTacToe2.Model.Exception;

namespace TicTacToe2.Model.Maps
{
    public class Map : ICloneable
    {
        private readonly Tile[,] _mapArray;

        public Map(int size = 3, Tile defaultTile = Tile.Empty)
        {
            Size = size;
            _mapArray = new Tile[size, size];
            SetAllCases(defaultTile);
        }

        public int Size { get; }

        private void SetAllCases(Tile tile)
        {
            for (int i = 0; i < _mapArray.GetLength(0); i++)
            for (int j = 0; j < _mapArray.GetLength(1); j++)
                _mapArray[i, j] = tile;
        }


        public void SetCase(Tile tile, int posX, int posY)
        {
            _mapArray[posY, posX] = tile;
        }

        //Input Shoud go
        // 7 | 8 | 9
        // 4 | 5 | 6
        // 1 | 2 | 3
        public void SetCase(Tile tile, int pos)
        {
            Coord coord = IntToCoord(pos);

            SetCase(tile, coord.X, coord.Y);
        }

        public Tile GetCase(int pos)
        {
            Coord coord = IntToCoord(pos);

            return GetCase(coord.X, coord.Y);
        }

        public Tile GetCase(int posX, int posY)
        {
            return _mapArray[posY, posX];
        }

        private Coord IntToCoord(int pos)
        {
            int posY = (int) Math.Ceiling((double) pos / Size - 1);

            int posX = pos % Size - 1;

            posY = posY * -1 + (Size - 1);

            if (posX < 0) posX = Size - 1;

            return new Coord(posX, posY);
        }

        public string GetStringRepresentation()
        {
            string message = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Tile tile = _mapArray[i, j];

                    switch (tile)
                    {
                        case Tile.Empty:
                            message += " ";
                            break;
                        default:
                            message += tile.ToString();
                            break;
                    }

                    if (j < 2) message += " | ";
                }

                message += "\n";
            }

            return message;
        }

        public bool HasEmptyCase()
        {
            for (int i = 0; i < _mapArray.GetLength(0); i++)
            for (int j = 0; j < _mapArray.GetLength(1); j++)
                if (_mapArray[i, j] == Tile.Empty)
                    return true;

            return false;
        }

        public object Clone()
        {
            Map newMap = new Map(Size);

            for (int i = 1; i < Size*Size+1; i++)
            {
                newMap.SetCase(this.GetCase(i), i);
            }

            return newMap;
        }
    }

    internal struct Coord
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}