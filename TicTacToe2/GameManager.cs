using TicTacToe2.Controller;
using TicTacToe2.Model;

namespace TicTacToe2
{
    public class GameManager
    {
        // Start is called before the first frame update
  
        private bool _waitingForPlayerAction = true;

        private Map _map;
    
        void Start()
        {
            _map = new Map();
            EventController.CallEvent("mapChange");
        }

        // Update is called onceper frame
        void Update()
        {
            if (_waitingForPlayerAction)
            {
                /*String input = Input.inputString;
            int value;
            if (Int32.TryParse(input, out value))
            {
                EventController.CallEvent("setCase", new string[1]{value.ToString()});
            }*/
            }
       
        }
    }
}
