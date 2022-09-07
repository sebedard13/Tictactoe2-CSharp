using System;

namespace TicTacToe2.View
{
    public static class ConsoleInterface
    {
        public static string GetLine()
        {
            return Console.In.ReadLine();
        }

        public static void WriteLine(string s)
        {
            Console.ResetColor();
            Console.WriteLine(s);
        }

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

        public static void WriteInfo(string s)
        {
            Console.Write("-Info- ");
            Console.ResetColor();
            Console.WriteLine(s);
        }
    }
}