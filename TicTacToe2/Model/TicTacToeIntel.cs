

namespace TicTacToe2.Model
{
   public class TicTacToeIntel
   {

      private int _a;
   
      public TicTacToeIntel(int a)
      {
         this._a = a;
      }

      public override string ToString()
      {
         return "AI"+_a.ToString();
      }
   }
}
