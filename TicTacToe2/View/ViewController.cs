using System;
using TicTacToe2.Controller.Event;
using TicTacToe2.Model.Players;

namespace TicTacToe2.View
{
    public static class ViewController
    {
        private static readonly EventController ViewEvent = new EventController();

        static ViewController()
        {
            ViewEvent.Listen("ChoosePlayer", ChoosePlayer);
            ViewEvent.Listen("ChooseRestart", ChooseRestart);
            ViewEvent.Listen("StartGame", StartGame);
            ViewEvent.Listen("UpdateMap", UpdateMap);
            ViewEvent.Listen("Tie", Tie);
            ViewEvent.Listen("PlayerWin", PlayerWin);
        }

        private static void ChoosePlayer(string[] obj)
        {
            ConsoleInterface.WriteLine("Player Selection");
        }

        private static void ChooseRestart(string[] obj)
        {
            ConsoleInterface.WriteLine("Restart the game? y/n");
        }
        
        private static void StartGame(string[] obj)
        {
            ConsoleInterface.WriteLine("Game Start");
        }
        
        private static void UpdateMap(string[] obj)
        {
            ConsoleInterface.WriteLine(obj[0]);
        }
        
        private static void Tie(string[] obj)
        {
            ConsoleInterface.WriteLine("It is a tie");
        }
        
        private static void PlayerWin(string[] obj)
        {
            ConsoleInterface.WriteLine("Player "+obj[0]+" win");
        }
        
        public static void Call(string eventName)
        {
            Call(eventName, Array.Empty<string>());
        }
        
        public static void Call(string key, string[] args)
        {
            ViewEvent.Call(key, args);
        }
    }
}