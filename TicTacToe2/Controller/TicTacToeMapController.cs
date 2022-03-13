using System;
using TicTacToe2.Model;
using TicTacToe2.View;

namespace TicTacToe2.Controller
{
    class TicTacToeController
    {
        private TicTacToeMap _obj;
        
        public TicTacToeController(TicTacToeMap obj)
        {
            _obj = obj;
            EventController.ListenEvent("setCase", SetCase);
            EventController.ListenEvent("mapChange", MapChange);
        }

        public void SetCase(String[] args)
        {
            int value = Int32.Parse(args[0]);
            _obj.SetCase(TicTacToeTile.X, value);
            EventController.CallEvent("mapChange");
        }
        
        public void MapChange(String[] args)
        {
           ConsoleInterface.WriteLine(_obj.GetStringRepresentation());
        }
    }
}