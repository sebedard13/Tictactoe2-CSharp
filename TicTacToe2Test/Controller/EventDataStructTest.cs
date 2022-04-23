using System;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe2.Controller.Event;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Utils.Debug;
using EventArgs = TicTacToe2.Controller.Event.EventList.EventArgs;

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
            Debug.Debuger = new DebugerAll();
        }

        [Test]
        public void Add_FillaToz_AllPresent()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            
            Assert.True(_struc.Contains("a"));
            Assert.True(_struc.Contains("b"));
            Assert.True(_struc.Contains("z"));
            Assert.False(_struc.Contains("A"));
            Assert.False(_struc.Contains("B"));
            Assert.False(_struc.Contains("Z"));
        }
        
        [Test]
        public void Att()
        {
            Action<StringArgs> action = args => {};
            Action<StringArgs> actionB = Action;
            Action<StringArgs> actionQ = Action2;

            Action<EventArgs> parent = new Action<EventArgs>(o => action((StringArgs)o));

            Action<EventArgs> action2 = new (o => action((StringArgs)o));
            Action<EventArgs> actionNew = new (o =>actionQ((StringArgs)o));

            bool Equals = parent.Equals(action2);
            bool Equals2 = parent == action2;
            
            Assert.True(true);
            Assert.AreEqual(action.Method.Name, actionB);
            Assert.AreEqual(parent.Method.Name, action2.Method.Name);
            Assert.AreNotEqual(parent, actionNew);
        }
        
        [Test]
        public void Add_FillAndAdd_InOrder()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            _struc.Add("ba", ActionDefault);
            _struc.Add("da", ActionDefault);
            _struc.Add("bc", ActionDefault);
            _struc.Add("jk", ActionDefault);
            _struc.Add("zb", ActionDefault);


            List<EventDataObject<EventArgs>> list = _struc.GetList();
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
            FillEventDataStructAToZ(_struc, ActionDefault);
            int startSize = _struc.Count;
            _struc.Add("a", ActionDefault);
            _struc.Add("b", ActionDefault);
            _struc.Add("c", ActionDefault);
            _struc.Add("j", ActionDefault);
            _struc.Add("z", ActionDefault);
            _struc.Add("z", Action);
            _struc.Add("b", Action);
            
            Assert.AreEqual(startSize+2, _struc.Count);
        }
        
        [Test]
        public void Add_FillIdentic_InOrder()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            _struc.Add("a", ActionDefault);
            _struc.Add("d", ActionDefault);
            _struc.Add("b", ActionDefault);
            _struc.Add("z", ActionDefault);
            

            List<EventDataObject<EventArgs>> list = _struc.GetList();
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
            FillEventDataStructAToZ(_struc, ActionDefault);
            
            for (int i = 0; i < 26; i++)
            {
                Assert.AreEqual(i, _struc.IndexOfKey(((char)(97+i)).ToString()));
            }
        }
        
        [Test]
        public void IndexOfKey_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            FillEventDataStructAToZ(_struc, ActionDefault);
            
            for (int i = 0; i < 26; i++)
            {
                int indexOfKey = _struc.IndexOfKey(((char)(97+i)).ToString());
                Assert.AreEqual(i*2, indexOfKey);
            }
        }
        
        [Test]
        public void Get_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            FillEventDataStructAToZ(_struc, ActionDefault);

            string key = "b";
            List<EventDataObject<EventArgs>> indexOfKey = _struc.Get(key);
            Assert.AreEqual(2, indexOfKey.Count);
            for (int i = 0; i < indexOfKey.Count; i++)
            {
                Assert.AreEqual(indexOfKey[i].Key, key);
            }
            
            
            string key2 = "z";
            List<EventDataObject<EventArgs>> indexOfKey2 = _struc.Get(key2);
            Assert.AreEqual(2, indexOfKey2.Count);
            for (int i = 0; i < indexOfKey.Count; i++)
            {
                Assert.AreEqual(indexOfKey2[i].Key, key2);
            }
        }
        
        [Test]
        public void RemoveEventName_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            FillEventDataStructAToZ(_struc, ActionDefault);
            int countStart = _struc.Count;
                
            string key = "b";
            _struc.RemoveEventName(key);
            List<EventDataObject<EventArgs>> indexOfKey = _struc.Get(key);
            Assert.AreEqual(0, indexOfKey.Count);
            Assert.AreEqual(countStart-2, _struc.Count);


            string key2 = "z";
            _struc.RemoveEventName(key2);
            List<EventDataObject<EventArgs>> indexOfKey2 = _struc.Get(key2);
            Assert.AreEqual(0, indexOfKey2.Count);
            Assert.AreEqual(countStart-4, _struc.Count);
        }
        
        [Test]
        public void Remove_Fill2Times_GoodIndex()
        {
            FillEventDataStructAToZ(_struc, ActionDefault);
            FillEventDataStructAToZ(_struc,  Action3);
            FillEventDataStructAToZ(_struc, Action);
            FillEventDataStructAToZ(_struc, Action2);
            FillEventDataStructAToZ(_struc, Action3);
            
            int countStart = _struc.Count;
                
            string key = "b";
            _struc.Remove(key, Action3);
            List<EventDataObject<EventArgs>> indexOfKey = _struc.Get(key);
            Assert.AreEqual(3, indexOfKey.Count);
            Assert.AreEqual(countStart-2, _struc.Count);


            string key2 = "z";
            _struc.Remove(key2, Action2);
            List<EventDataObject<EventArgs>> indexOfKey2 = _struc.Get(key2);
            Assert.AreEqual(4, indexOfKey2.Count);
            Assert.AreEqual(countStart-3, _struc.Count);
        }


        private void FillEventDataStructAToZ(EventDataStruct struc, Action<StringArgs> action)
        {
            for (int i = 0; i < 26; i++)
            {
                struc.Add(((char)(97+i)).ToString(), action);
            }
        }
        
        
        private void Action(StringArgs args)
        {
            String a = "a";
        }
        private void Action2(StringArgs args)
        {
            String b = "b";
        }
        private void Action3(StringArgs args)
        {
            String c = "c";
        }
        private void ActionDefault(StringArgs args)
        {
            String d = "d";
        }
        
    }
}