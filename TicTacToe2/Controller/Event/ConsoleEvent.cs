using System;

namespace TicTacToe2.Controller.Event
{
    public class ConsoleEvent
    {
        public string EventName { get; }

        public string[] Args { get; }

        public ConsoleEvent(string eventName, string[] eventArgs)
        {
            EventName = eventName;
            Args = eventArgs;
        }
    }
}