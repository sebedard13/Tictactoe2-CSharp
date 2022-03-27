

namespace TicTacToe2.Model
{
   public class IA
   {

      private int _a;
   
      public IA(int a)
      {
         this._a = a;
      }

      public override string ToString()
      {
         return "AI"+_a.ToString();
      }
   }
}
