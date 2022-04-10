using System;
using System.Linq;
using TicTacToe2.Controller.Event;
using TicTacToe2.Model;
using TicTacToe2.Model.Players;

namespace TicTacToe2.View
{
    public class GetFromView
    {
        public static bool Boolean()
        {
            
            bool? answer = null;
            EventController eventController = new EventController();
            eventController.Listen("y", strings =>
            {
                answer = true;
            });
            
            eventController.Listen("n", strings =>
            {
                answer = false;
            });
            while (answer == null)
            {
                GetUserEvent(eventController);
            }

            return answer.Value;
        }
        
        static void GetUserEvent(EventController eventController)
        {
            string a = ConsoleInterface.GetLine();
            if (!String.IsNullOrEmpty(a))
            {
                string[] list = a.Split(" ");
                string eventS = list[0];

                string[] eventArgs = list.Where((e, i) => i != 0).ToArray();
                eventController.Call(eventS,eventArgs);
            }
        }
        
        public static Player Player(Tile tile)
        {
            ConsoleInterface.WriteLine("User/Random");
            Player player = null;
            string eventName = "set";
            EventController eventController = new EventController();
            
            eventController.Listen("User", strings =>
            {
                player = new UserPlayer(tile);
                eventController.Remove(eventName);
            });
            eventController.Listen("Random", strings =>
            {
                player = new RandomPlayer(tile);
                eventController.Remove(eventName);
            });
            while (player == null)
            {
                GetUserEvent(eventController);
            }

            return player;
        }
        
        public static int Integer(int minIncluded, int max)
        {
            int inputInt = -1;
            bool hasValidInt =false;
            EventController eventController = new EventController();
            do
            {
                String input = ConsoleInterface.GetLine();

                try
                {
                    inputInt = Int16.Parse(input);
                    if (inputInt >= minIncluded && inputInt < max)
                    {
                        hasValidInt = true;
                    }
                    
                }
                catch (Exception e)
                {
                    hasValidInt = false;
                }
                
            } while (!hasValidInt);

            return inputInt;
        }
    }
}