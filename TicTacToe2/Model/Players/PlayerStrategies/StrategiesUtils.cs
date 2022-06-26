using System.Collections.Generic;
using TicTacToe2.Model.Players;
using System.Collections;

namespace Model.Players.PlayerStrategies{
    public static class StrategiesUtils{

        private static Dictionary<string, PlayerStrategy> strategyMap = createDictionary();

        private static Dictionary<string, PlayerStrategy> createDictionary(){
            Dictionary<string, PlayerStrategy> dic = new Dictionary<string, PlayerStrategy>();

            dic.Add("user", new UserPlayer());
            dic.Add("random", new RandomPlayer());

            return dic;
        }

        public static bool isValidStrategy(string value){
            return strategyMap.ContainsKey(value);
        }

        public static PlayerStrategy GetPlayerStrategy (string value){
            return strategyMap.GetValueOrDefault(value);
        }

        public static string listStrategy(){
            string listString = "";
            foreach (string a in strategyMap.Keys){
                listString+= a+", ";
            }
            return listString.Substring(0, listString.Length-2);
        }

    }
}