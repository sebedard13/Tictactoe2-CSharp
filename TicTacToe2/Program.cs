using System;
using System.Linq;
using TicTacToe2.Controller;
using TicTacToe2.Model;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;

namespace TicTacToe2
{
    class Program
    {
        static private TicTacToeMap _map = new TicTacToeMap();

        static public Boolean Runing = true;
        
        static void Main(string[] args)
        {
            Debug.Debuger = new DebugerAll();
            
            EventController.ListenEvent("close", strings =>
            {
                Runing = false;
            });
            
            while (Runing)
            {
                string a = ConsoleInterface.getLine();
                if (!String.IsNullOrEmpty(a))
                {
                    string[] list = a.Split(" ");
                    string eventS = list[0];

                    string[] eventArgs = list.Where((e, i) => i != 0).ToArray();
                    EventController.CallEvent(eventS,eventArgs);
                }
               
            }
            
        }
    }
}