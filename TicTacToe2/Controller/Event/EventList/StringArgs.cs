using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public class StringArgs : EventArgs
    {
        public String[] Args { get; }

        public StringArgs()
        {}

        public StringArgs(string[] args)
        {
            Args = args;
        }

        public override string GetEventName()
        {
            throw new NotImplementedException();
        }

        public override string GetEventDescription()
        {
            return EventDescription;
        }

        public static string EventDescription = "No valid Description";
    }
}