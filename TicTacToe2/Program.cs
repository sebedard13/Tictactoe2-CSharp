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
        static private Map _map = new Map();

        static public Boolean Running = true;
        
        static void Main(string[] args)
        {
            Debug.Debuger = new DebugerAll();
            
            EventController.ListenEvent("close", strings =>
            {
                Running = false;
            });
            
            while (Running)
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