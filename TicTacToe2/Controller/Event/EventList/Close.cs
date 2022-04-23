using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public class Close : EventArgs
    {
        public new static string EventName = "close";
        public new static string EventDescription = "Close the application";

        public int Value { get; set; }
        
    }
}