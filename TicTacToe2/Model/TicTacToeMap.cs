using System;
using TicTacToe2.Controller;
using TicTacToe2.Model.Exception;

namespace TicTacToe2.Model
{
    public enum TicTacToeTile
    {
        X,O,Empty
    }
    
    public class TicTacToeMap
    {
        private int _size;

        private TicTacToeTile[,] _mapArray;

        private TicTacToeController _controller;

        public TicTacToeMap(int size = 3, TicTacToeTile defaultTile = TicTacToeTile.Empty)
        {
            _size = size;
            _mapArray = new TicTacToeTile[size, size];
            _controller = new TicTacToeController(this);
            SetAllCases(defaultTile);
        }

        public void SetAllCases(TicTacToeTile tile)
        {
            for (int i=0; i<_mapArray.GetLength(0); i++)
            {
                for (int j=0; j<_mapArray.GetLength(1); j++)
                {
                    _mapArray[i, j] = tile;
                }
            }
        }
        

        public void SetCase(TicTacToeTile tile, int posX, int posY)
        {
            try
            {
                _mapArray[posY, posX] = tile;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CaseNotValidException();
            }
        }

        
        //Input Shoud go
        // 7 | 8 | 9
        // 4 | 5 | 6
        // 1 | 2 | 3
        public void SetCase(TicTacToeTile tile, int pos)
        {
            int posY = (int) Math.Ceiling((double)pos / _size - 1);
            
            int posX = pos % _size-1;

            posY = posY * -1 +  (_size-1);

            if (posX < 0)
            {
                posX = _size-1;
            }
         
            SetCase(tile, posX, posY);
        }
        
        public String GetStringRepresentation()
        {
            String message = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TicTacToeTile tile =  _mapArray[i,j];

                    switch (tile)
                    {
                        case TicTacToeTile.Empty:
                            message += " ";
                            break;
                        default:
                            message += tile.ToString();
                            break;
                    }
                    if (j<2)
                    {
                        message += " | ";
                    }
                }
                message += "\n";
            }

            return message;
        }
    }
}