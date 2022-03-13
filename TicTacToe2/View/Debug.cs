using System;

namespace TicTacToe2.View
{
    public class Debug
    {
        public static void WriteError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-ERROR- ");
            Console.ResetColor();
            Console.WriteLine(s);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-ERROR- ");
            Console.ResetColor();
            Console.WriteLine("Future command may be compromised");
        }
        
        public static void WriteWarning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("-WARNING- ");
            Console.ResetColor();
            Console.WriteLine(s);
        }
    }
}