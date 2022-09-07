using TicTacToe2.Controller.Event;
using TicTacToe2.Controller.Event.EventList;

namespace TicTacToe2.Controller.States
{
    public abstract class State
    {
        protected State()
        {
            UserEvents.Listen<Close>(strings => { Program.Running = false; });
        }

        public EventController UserEvents { get; } = new();

        public void Handle(ConsoleEvent consoleEvent)
        {
            UserEvents.Call(consoleEvent.EventName, consoleEvent.Args);
        }
    }
}