namespace TicTacToe2.Model.Exception
{
    internal class CaseNotValidException : System.Exception
    {
        public CaseNotValidException()
        {
        }

        public CaseNotValidException(string s) : base(s)
        {
        }

        public CaseNotValidException(string s, System.Exception e) : base(s, e)
        {
        }
    }
}