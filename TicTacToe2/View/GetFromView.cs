using System;
using System.Linq;
using TicTacToe2.Controller.Event;
namespace TicTacToe2.View
{
    public static class GetFromView
    {
        public static ConsoleEvent GetUserEvent(EventController eventController)
        {
            string a = ConsoleInterface.GetLine();
            if (!String.IsNullOrEmpty(a))
            {
                string[] list = a.Split(" ");
                string eventName = list[0];

                string[] eventArgs = list.Where((e, i) => i != 0).ToArray();
                return new ConsoleEvent(eventName, eventArgs);
            }

            return null;
        }
    }
}