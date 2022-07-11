using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe2.Model;
using TicTacToe2.Model.Maps;
using TicTacToe2.Model.Players;

namespace Test.Model.Players.PlayerStrategies
{
    internal class MinMaxPlayerTest
    {

        [Test]
        public void MinMax_StopWin_GoodMove()
        {
            MinMaxPlayer p = new MinMaxPlayer();
            Map map = new Map();



            map.SetCase(Tile.X, 3);
            map.SetCase(Tile.O, 4);
            map.SetCase(Tile.O, 5);
            Player current = new Player(Tile.X);
            Assert.AreEqual(p.MinMax(new MapContainer(map, current, new Player(Tile.O)),current, 9, 0).move, 6);
        }

        [Test]
        public void MinMax_Win_GoodMove()
        {
            MinMaxPlayer p = new MinMaxPlayer();
            Map map = new Map();

            map.SetCase(Tile.X, 5);
            map.SetCase(Tile.O, 7);
            map.SetCase(Tile.X, 1);
            map.SetCase(Tile.O, 3);
            Player current = new Player(Tile.X);
            
            Assert.AreEqual(p.MinMax(new MapContainer(map, current, new Player(Tile.O)), current, 3, 0).move, 9);
        }

        [Test]
        public void MinMax_OneSideMove_GoodStart()
        {
            MinMaxPlayer p = new MinMaxPlayer();
            Map map = new Map();
            map.SetCase(Tile.O, 4);

            Player current = new Player(Tile.X);
            int moveFound = p.MinMax(new MapContainer(map, current, new Player(Tile.O)), current, 10, 0).move;

            //Good move center
            Assert.AreEqual(moveFound,5);
        }

        [Test]
        public void MinMax_EmptyAll_GoodStart()
        {
            MinMaxPlayer p = new MinMaxPlayer();
            Map map = new Map();

            Player current = new Player(Tile.X);
            int moveFound = p.MinMax(new MapContainer(map, current, new Player(Tile.O)), current, 9, 0).move;

            //Good move == 1,3,5,7
            Assert.True(moveFound % 2 == 1 && moveFound != 5);
        }
    }
}
