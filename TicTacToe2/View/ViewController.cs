using System;
using TicTacToe2.Controller.Event;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Model.Players;

namespace TicTacToe2.View
{
    public static class ViewController
    {
        private static readonly EventController ViewEvent = new EventController();

        static ViewController()
        {
            ViewEvent.Listen("chooseplayer", ChoosePlayer);
            ViewEvent.Listen("chooserestart", ChooseRestart);
            ViewEvent.Listen("startgame", StartGame);
            ViewEvent.Listen("updatemap", UpdateMap);
            ViewEvent.Listen("tie", Tie);
            ViewEvent.Listen("playerwin", PlayerWin);
        }

        private static void ChoosePlayer(StringArgs obj)
        {
            ConsoleInterface.WriteLine("Player Selection");
        }

        private static void ChooseRestart(StringArgs obj)
        {
            ConsoleInterface.WriteLine("Restart the game? y/n");
        }
        
        private static void StartGame(StringArgs obj)
        {
            ConsoleInterface.WriteLine("Game Start");
        }
        
        private static void UpdateMap(StringArgs obj)
        {
            ConsoleInterface.WriteLine(obj.Args[0]);
        }
        
        private static void Tie(StringArgs obj)
        {
            ConsoleInterface.WriteLine("It is a tie");
        }
        
        private static void PlayerWin(StringArgs obj)
        {
            ConsoleInterface.WriteLine("Player "+obj.Args[0]+" win");
        }
        
        public static void Call(string eventName)
        {
            Call(eventName, Array.Empty<string>());
        }
        
        public static void Call(string key, string[] args)
        {
            ViewEvent.Call(key, args);
        }

        public static void BadEvent(ArgumentException e){
            ConsoleInterface.WriteLine("Mauvais argument:" + e.Message);
        }
    }
}