using System;

namespace TicTacToe2.View
{
    public class ConsoleInterface
    {

        
        public static string getLine()
        {
            return Console.In.ReadLine();
        }
        
        public static void WriteLine(string s)
        {
            Console.ResetColor();
            Console.WriteLine(s);
        }

    
        
    }
}