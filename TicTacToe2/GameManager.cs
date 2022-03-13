using Script;
using TicTacToe2.Model;

namespace TicTacToe2
{
    public class GameManager
    {
        // Start is called before the first frame update
  
        private bool _waitingForPlayerAction = true;

        private TicTacToeMap _map;
    
        void Start()
        {
            _map = new TicTacToeMap();
            EventController.CallEvent("mapChange");
        }

        // Update is called once per frame
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
