using TicTacToe2.View;

namespace TicTacToe2.Utils.Debug
{
    public abstract class Debug
    {

        public static Debug Debuger = new DebugerNone();

        protected abstract void WriteInfo(string s);
        
        public static void Info(string s)
        {
            Debuger.WriteInfo(s);
        }
        
        protected abstract void WriteError(string s);

        public static void Error(string s)
        {
            Debuger.WriteError(s);
        }
        
        protected abstract void WriteWarning(string s);
        
        public static void Warning(string s)
        {
            Debuger.WriteWarning(s);
        }
    }
}