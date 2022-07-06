using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public class Play : EventArgs
    {
        public int Position { get; private set; }
        public override string GetEventName()
        {
            return "play";
        }

        public override string GetEventDescription()
        {
            return "play a piece on the tictactoe board:\n" +
                   " 7 | 8 | 9\n" +
                   " 4 | 5 | 6\n" +
                   " 1 | 2 | 3";
        }

        public override void setArguments(string[] args)
        {
            try
            {
                Position = short.Parse(args[0]);
            }
            catch (Exception e)
            {
                throw new ArgumentException(
                    GetEventName()+" (int)Player number 1 to 9");
            }
           
        }
    }
}