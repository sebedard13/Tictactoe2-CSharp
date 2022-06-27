namespace TicTacToe2.Controller.Event
{
    public class ConsoleEvent
    {
        public ConsoleEvent(string eventName, string[] eventArgs)
        {
            EventName = eventName;
            Args = eventArgs;
        }

        public string EventName { get; }

        public string[] Args { get; }
    }
}