using System;
using System.Linq;
using Script;
using TicTacToe2.Model;

namespace TicTacToe2
{
    class Program
    {
        static private TicTacToeMap _map = new TicTacToeMap();

        static public Boolean Runing = true;
        
        static void Main(string[] args)
        {
            EventController.ListenEvent("close", strings =>
            {
                Runing = false;
            });
            
            while (Runing)
            {
                string a = Console.In.ReadLine();
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