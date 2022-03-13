
using System;

namespace TicTacToe2.Model.Exception
{
    class CaseNotValidException : System.Exception
    {
     
        
        public CaseNotValidException():base()
        {
            
        }
        
        public CaseNotValidException(String s):base(s)
        {
            
        }

        public CaseNotValidException(String s, System.Exception e) : base(s, e)
        {
            
        }
    }
}

