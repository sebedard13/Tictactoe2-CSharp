using System;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe2.Controller;
using TicTacToe2.Controller.Event;

namespace Test.Controller
{
    public class EventDataStructTest
    {
        private EventDataStruct _struc;
        
        [SetUp]
        public void Setup()
        {
            _struc = new EventDataStruct();
            _struc.DoubleAction = true;
        }

        [Test]
        public void Add_FillaToz_AllPresent()
        {
            FillEventDataStructAToZ(_struc);
            
            Assert.True(_struc.Contains("a"));
            Assert.True(_struc.Contains("b"));
            Assert.True(_struc.Contains("z"));
            Assert.False(_struc.Contains("A"));
            Assert.False(_struc.Contains("B"));
            Assert.False(_struc.Contains("Z"));
        }
        
        [Test]
        public void Add_FillAndAdd_InOrder()
        {
            FillEventDataStructAToZ(_struc);
            _struc.Add("ba", null);
            _struc.Add("da", null);
            _struc.Add("bc", null);
            _struc.Add("jk", null);
            _struc.Add("zb", null);


            List<Event> list = _struc.GetList();
            Assert.AreEqual("ba", list[2].Key);
            Assert.AreEqual("bc", list[3].Key);
            Assert.AreEqual("da", list[6].Key);
            Assert.AreEqual("jk", list[13].Key);
            Assert.AreEqual("zb", list[30].Key);
        }
        
        [Test]
        public void Add_FillAndAdd_NoDouble()
        {
            _struc.DoubleAction = false;
            FillEventDataStructAToZ(_struc);
            int startSize = _struc.Count;
            _struc.Add("a", null);
            _struc.Add("b", null);
            _struc.Add("c", null);
            _struc.Add("j", null);
            _struc.Add("z", null);
            _struc.Add("z", Action);
            _struc.Add("b", Action);
            
            Assert.AreEqual(startSize+2, _struc.Count);
        }
        
        [Test]
        public void Add_FillIdentic_InOrder()
        {
            FillEventDataStructAToZ(_struc);
            _struc.Add("a", null);
            _struc.Add("d", null);
            _struc.Add("b", null);
            _struc.Add("z", null);
            

            List<Event> list = _struc.GetList();
            Assert.AreEqual("a", list[0].Key);
            Assert.AreEqual("a", list[1].Key);
            Assert.AreEqual("b", list[2].Key);
            Assert.AreEqual("b", list[3].Key);
            Assert.AreEqual("d", list[5].Key);
            Assert.AreEqual("d", list[6].Key);
            Assert.AreEqual("z", list[28].Key);
            Assert.AreEqual("z", list[29].Key);
        }

        [Test]
        public void IndexOfKey_FillAToZ_GoodIndex()
        {
            FillEventDataStructAToZ(_struc);
            
            for (int i = 0; i < 26; i++)
            {
                Assert.AreEqual(i, _struc.IndexOfKey(((char)(97+i)).ToString()));
            }
        }
        
        [Test]
        public void IndexOfKey_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc);
            FillEventDataStructAToZ(_struc);
            
            for (int i = 0; i < 26; i++)
            {
                int indexOfKey = _struc.IndexOfKey(((char)(97+i)).ToString());
                Assert.AreEqual(i*2, indexOfKey);
            }
        }
        
        [Test]
        public void Get_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc);
            FillEventDataStructAToZ(_struc);

            string key = "b";
            List<Event> indexOfKey = _struc.Get(key);
            Assert.AreEqual(2, indexOfKey.Count);
            for (int i = 0; i < indexOfKey.Count; i++)
            {
                Assert.AreEqual(indexOfKey[i].Key, key);
            }
            
            
            string key2 = "z";
            List<Event> indexOfKey2 = _struc.Get(key2);
            Assert.AreEqual(2, indexOfKey2.Count);
            for (int i = 0; i < indexOfKey.Count; i++)
            {
                Assert.AreEqual(indexOfKey2[i].Key, key2);
            }
        }
        
        [Test]
        public void RemoveEventName_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc);
            FillEventDataStructAToZ(_struc);
            int countStart = _struc.Count;
                
            string key = "b";
            _struc.RemoveEventName(key);
            List<Event> indexOfKey = _struc.Get(key);
            Assert.AreEqual(0, indexOfKey.Count);
            Assert.AreEqual(countStart-2, _struc.Count);


            string key2 = "z";
            _struc.RemoveEventName(key2);
            List<Event> indexOfKey2 = _struc.Get(key2);
            Assert.AreEqual(0, indexOfKey2.Count);
            Assert.AreEqual(countStart-4, _struc.Count);
        }
        
        [Test]
        public void Remove_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc);
            FillEventDataStructAToZ(_struc, Action3);
            FillEventDataStructAToZ(_struc,Action);
            FillEventDataStructAToZ(_struc, Action2);
            FillEventDataStructAToZ(_struc, Action3);
            
            int countStart = _struc.Count;
                
            string key = "b";
            _struc.Remove(key, Action3);
            List<Event> indexOfKey = _struc.Get(key);
            Assert.AreEqual(3, indexOfKey.Count);
            Assert.AreEqual(countStart-2, _struc.Count);


            string key2 = "z";
            _struc.Remove(key2, Action2);
            List<Event> indexOfKey2 = _struc.Get(key2);
            Assert.AreEqual(4, indexOfKey2.Count);
            Assert.AreEqual(countStart-3, _struc.Count);
        }


        private void FillEventDataStructAToZ(EventDataStruct struc, Action<String[]> action = null)
        {
            for (int i = 0; i < 26; i++)
            {
                struc.Add(((char)(97+i)).ToString(), action);
            }
        }
        
        
        private void Action(String[] args)
        {
           
        }
        private void Action2(String[] args)
        {
           
        }
        private void Action3(String[] args)
        {
           
        }
        private void Action4(String[] args)
        {
           
        }
    }
}