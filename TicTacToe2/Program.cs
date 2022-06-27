using TicTacToe2.Controller.Event;
using TicTacToe2.Controller.States;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;

namespace TicTacToe2
{
    internal static class Program
    {
        public static State CurrentState { get; set; } = new StatePlayerSelect();

        public static bool Running { get; set; } = true;

        private static void Main(string[] args)
        {
            Debug.Debuger = new DebugerAll();
            while (Running)
            {
                ConsoleEvent currentEvent = GetFromView.GetUserEvent(CurrentState.UserEvents);
                if (currentEvent != null) CurrentState.Handle(currentEvent);
            }
        }
    }
}