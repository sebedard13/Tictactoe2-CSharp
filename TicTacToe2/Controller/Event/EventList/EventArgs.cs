using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public class EventArgs
    { 
        public static string EventName = "ff";
        public static string EventDescription = "fee";

        public string GetEventName()
        {
            return EventName;
        }
        
        public string GetEventDescription()
        {
            return EventDescription;
        }
    }
}