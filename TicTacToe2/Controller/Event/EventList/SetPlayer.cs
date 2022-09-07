using System;
using Model.Players.PlayerStrategies;

namespace TicTacToe2.Controller.Event.EventList
{
    public class SetPlayer : EventArgs
    {
        public int playerNo { get; set; }
        public string playerStrategie { get; set; }

        public override string GetEventDescription()
        {
            return "Set player for the game with : " + StrategiesUtils.listStrategy();
        }

        public override string GetEventName()
        {
            return "setplayer";
        }

        public override void setArguments(string[] args)
        {
            try
            {
                playerNo = int.Parse(args[0]) - 1;

                playerStrategie = args[1];
                if (!StrategiesUtils.isValidStrategy(playerStrategie) || playerNo < 0 || playerNo > 1)
                    throw new Exception();
            }
            catch (Exception e)
            {
                throw new ArgumentException(
                    "setplayer (int)Player number 1 or 2 (string)PlayerStrategie User or Random");
            }
        }
    }
}