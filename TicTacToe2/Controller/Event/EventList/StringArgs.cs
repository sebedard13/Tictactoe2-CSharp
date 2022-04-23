using System;

namespace TicTacToe2.Controller.Event.EventList
{
    public class StringArgs : EventArgs
    {
        public String[] Args { get; }

        public StringArgs()
        {}

        public StringArgs(string[] args)
        {
            Args = args;
        }
    }
}