
using System;

namespace TicTacToe2
{
    class CaseNotValidException : Exception
    {
     
        
        public CaseNotValidException():base()
        {
            
        }
        
        public CaseNotValidException(String s):base(s)
        {
            
        }

        public CaseNotValidException(String s, Exception e) : base(s, e)
        {
            
        }
    }
}

