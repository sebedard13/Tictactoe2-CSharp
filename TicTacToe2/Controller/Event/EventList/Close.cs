namespace TicTacToe2.Controller.Event.EventList
{
    public class Close : EventArgs
    {
        private static readonly string EventName = "close";
        private static readonly string EventDescription = "Close the application";

        public override string GetEventName()
        {
            return EventName;
        }

        public override string GetEventDescription()
        {
            return EventDescription;
        }

        public override void setArguments(string[] args)
        {
            //No args to do
        }
    }
}