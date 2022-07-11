using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe2.Model;
using TicTacToe2.Model.Maps;
using TicTacToe2.Model.Players;

namespace Test.Model.Maps
{
    internal class MapContainerTest
    {
        Map map;
        Player currentPlayer = new Player(Tile.O);
        Player nextPlayer = new Player(Tile.X);

        [SetUp]
        public void beforeAll()
        {
            map = new Map();
        }

        [Test]
        public void GetMoves_NewMap_All9()
        {
            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            List<int> moves = mapContainer.GetMoves();

            Assert.AreEqual(moves.Count, 9);
            Assert.Contains(9, moves);
            Assert.Contains(8, moves);
            Assert.Contains(7, moves);
            Assert.Contains(6, moves);
            Assert.Contains(5, moves);
            Assert.Contains(4, moves);
            Assert.Contains(3, moves);
            Assert.Contains(2, moves);
            Assert.Contains(1, moves);
        }

        [Test]
        public void GetMoves_MapWithMove_All9()
        {
            map.SetCase(Tile.X, 7);
            map.SetCase(Tile.X, 9);
            map.SetCase(Tile.X, 2);

            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            List<int> moves = mapContainer.GetMoves();

            Assert.AreEqual(moves.Count, 6);
            Assert.Contains(8, moves);
            Assert.Contains(6, moves);
            Assert.Contains(5, moves);
            Assert.Contains(4, moves);
            Assert.Contains(3, moves);
            Assert.Contains(1, moves);
        }

        [Test]
        public void DoMoveOn_MapEmpty_1Move()
        {
            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            Map newMap = mapContainer.doMoveOn(6);

            Assert.AreEqual(newMap.GetCase(9), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(8), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(7), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(6), Tile.O);
            Assert.AreEqual(newMap.GetCase(5), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(4), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(3), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(2), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(1), Tile.Empty);
            Assert.AreNotSame(map, newMap);
        }

        [Test]
        public void DoMoveOn_MaMoves_4Move()
        {
            map.SetCase(Tile.X, 7);
            map.SetCase(Tile.X, 9);
            map.SetCase(Tile.X, 2);
            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            Map newMap = mapContainer.doMoveOn(6);

            Assert.AreEqual(newMap.GetCase(9), Tile.X);
            Assert.AreEqual(newMap.GetCase(8), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(7), Tile.X);
            Assert.AreEqual(newMap.GetCase(6), Tile.O);
            Assert.AreEqual(newMap.GetCase(5), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(4), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(3), Tile.Empty);
            Assert.AreEqual(newMap.GetCase(2), Tile.X);
            Assert.AreEqual(newMap.GetCase(1), Tile.Empty);
            Assert.AreNotSame(map, newMap);
        }

        [Test]
        public void CurrentPlayer_MapContainer1_GoodPlayer()
        {

            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            Player newPlayer = mapContainer.CurrentPlayer();

            Assert.AreSame(newPlayer, currentPlayer);

        }

        [Test]
        public void CurrentPlayer_MapContainerConstructor_GoodPlayer()
        {

            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);
            Player newPlayer = mapContainer.CurrentPlayer();
            Assert.AreSame(newPlayer, currentPlayer);

            MapContainer newMapContainer = new(mapContainer, map);
            Player newPlayer2 = newMapContainer.CurrentPlayer();
            Assert.AreSame(newPlayer2, nextPlayer);

            MapContainer newMapContainer3 = new(newMapContainer, map);
            Player newPlayer3 = newMapContainer3.CurrentPlayer();
            Assert.AreSame(newPlayer3, currentPlayer);

        }

        [Test]
        public void Evaluate_Empty_0()
        {

            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            int value = mapContainer.Evaluate(currentPlayer);
            Assert.AreEqual(value, 0);

        }

        [Test]
        public void Evaluate_NoWin_0()
        {
            map.SetCase(currentPlayer.PlayerTile, 7);
            map.SetCase(currentPlayer.PlayerTile, 5);
            map.SetCase(nextPlayer.PlayerTile, 3);
            map.SetCase(nextPlayer.PlayerTile, 1);
            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            int value = mapContainer.Evaluate(currentPlayer);
            Assert.AreEqual(value, 0);
        }

        [Test]
        public void Evaluate_PoWin_200()
        {
            map.SetCase(currentPlayer.PlayerTile, 7);
            map.SetCase(currentPlayer.PlayerTile, 5);
            map.SetCase(currentPlayer.PlayerTile, 3);
            map.SetCase(nextPlayer.PlayerTile, 1);
            map.SetCase(nextPlayer.PlayerTile, 2);
            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            int valueCurrent = mapContainer.Evaluate(currentPlayer);
            Assert.AreEqual(valueCurrent, 200);

            int valueNext = mapContainer.Evaluate(nextPlayer);
            Assert.AreEqual(valueNext, -200);
        }

        [Test]
        public void Evaluate_Tie_0()
        {
            map.SetCase(currentPlayer.PlayerTile, 7);
            map.SetCase(currentPlayer.PlayerTile, 9);
            map.SetCase(currentPlayer.PlayerTile, 5);
            map.SetCase(currentPlayer.PlayerTile, 2);
            map.SetCase(nextPlayer.PlayerTile, 8);
            map.SetCase(nextPlayer.PlayerTile, 4);
            map.SetCase(nextPlayer.PlayerTile, 1);
            map.SetCase(nextPlayer.PlayerTile, 6);
            map.SetCase(nextPlayer.PlayerTile, 3);
            MapContainer mapContainer = new(map, currentPlayer, nextPlayer);

            int valueCurrent = mapContainer.Evaluate(currentPlayer);
            Assert.AreEqual(valueCurrent, 0);

            int valueNext = mapContainer.Evaluate(nextPlayer);
            Assert.AreEqual(valueNext, 0);
        }

    }
}
