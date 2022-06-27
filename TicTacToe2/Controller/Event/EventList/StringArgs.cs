using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public class StringArgs : EventArgs
    {
        public static string EventDescription = "No valid Description";
        public string[] Args { get; set; }

        public override string GetEventName()
        {
            throw new NotImplementedException();
        }

        public override string GetEventDescription()
        {
            return EventDescription;
        }

        public override void setArguments(string[] args)
        {
            Args = args;
        }
    }
}