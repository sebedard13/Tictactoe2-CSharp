
using System;
using TicTacToe2.Controller.Event;
using TicTacToe2.Controller.Event.EventList;

namespace TicTacToe2.Controller.States
{
    public abstract class State
    {
        public EventController UserEvents { get; } = new EventController();

        protected State()
        {
            UserEvents.Listen<Close>(strings =>
            {
                Program.Running = false;
            } );
        }

        public void Handle(ConsoleEvent consoleEvent)
        {
            UserEvents.Call(consoleEvent.EventName, consoleEvent.Args);
        }
    }
}