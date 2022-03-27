using TicTacToe2.View;

namespace TicTacToe2.Utils.Debug
{
    public class DebugerAll : Debug
    {
        protected override void WriteInfo(string s)
        {
            ConsoleInterface.WriteInfo(s);
        }

        protected override void WriteError(string s)
        {
            ConsoleInterface.WriteError(s);
        }

        protected override void WriteWarning(string s)
        {
            ConsoleInterface.WriteWarning(s);
        }
    }
}