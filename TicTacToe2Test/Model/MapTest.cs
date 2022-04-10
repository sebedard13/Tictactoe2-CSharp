﻿using NUnit.Framework;
using TicTacToe2.Model;
using TicTacToe2.Model.Maps;

namespace Test.Model
{
    public class MapTest
    {
        
        private Map _map;
        
        [SetUp]
        public void Setup()
        {
            _map = new Map();
        }
        
        [Test]
        public void HasLine_Column9_True()
        {
            _map.SetCase(Tile.O, 9);
            _map.SetCase(Tile.O, 6);
            _map.SetCase(Tile.O, 3);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Column8_True()
        {
            _map.SetCase(Tile.O, 8);
            _map.SetCase(Tile.O, 5);
            _map.SetCase(Tile.O, 2);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Column7_True()
        {
            _map.SetCase(Tile.O, 7);
            _map.SetCase(Tile.O, 4);
            _map.SetCase(Tile.O, 1);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Line7_True()
        {
            _map.SetCase(Tile.O, 7);
            _map.SetCase(Tile.O, 8);
            _map.SetCase(Tile.O, 9);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Line4_True()
        {
            _map.SetCase(Tile.O, 4);
            _map.SetCase(Tile.O, 5);
            _map.SetCase(Tile.O, 6);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Line1_True()
        {
            _map.SetCase(Tile.O, 1);
            _map.SetCase(Tile.O, 2);
            _map.SetCase(Tile.O, 3);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Diagonal7_True()
        {
            _map.SetCase(Tile.O, 7);
            _map.SetCase(Tile.O, 5);
            _map.SetCase(Tile.O, 3);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Diagonal9_True()
        {
            _map.SetCase(Tile.O, 9);
            _map.SetCase(Tile.O, 5);
            _map.SetCase(Tile.O, 1);
            
            Assert.True(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Error1_False()
        {
            _map.SetCase(Tile.O, 7);
            _map.SetCase(Tile.O, 5);
            _map.SetCase(Tile.O, 6);
            _map.SetCase(Tile.O, 9);
            
            Assert.False(MapUtils.TileHasWin(Tile.O, _map));
        }
        
        [Test]
        public void HasLine_Error2_False()
        {
            _map.SetCase(Tile.O, 8);
            _map.SetCase(Tile.X, 4);
            _map.SetCase(Tile.X, 5);
            _map.SetCase(Tile.O, 6);
            _map.SetCase(Tile.O, 1);
            
            Assert.False(MapUtils.TileHasWin(Tile.O, _map));
        }
    }
}