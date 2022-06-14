using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public abstract class EventArgs
    {

        public abstract string GetEventName();

        public abstract string GetEventDescription();
    }
}