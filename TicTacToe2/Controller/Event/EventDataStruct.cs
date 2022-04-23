using System;
using System.Collections.Generic;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Utils.Debug;
using EventArgs = TicTacToe2.Controller.Event.EventList.EventArgs;

namespace TicTacToe2.Controller.Event
{
    
    public class EventDataStruct
    {
        private readonly List<EventDataObject<EventList.EventArgs>> _list = new(); 

        public int Count
            => _list.Count;

        public bool DoubleAction { get; set; } = false;

        private void privateAdd<T>(string key, Action<T> value) where T : notnull, EventArgs, new()
        {
            int hash = value.GetHashCode();
            EventDataObject<EventArgs> newObj = new (key, o => value((T)o));

            if (DoubleAction)
            {
                int index = IndexOfKeyIndex(newObj);

                _list.Insert(index, newObj);
            }
            else
            {
                int index = IndexOfKey(newObj.Key);

                if (index < 0)
                {
                    //No identic key
                    index = ~index;
                    _list.Insert(index, newObj);
                }
                else
                {
                    int indexLoop = index;
                    while (TryFindKey(indexLoop) == newObj.Key)
                    {
                        Action<EventArgs> tryFindAction = TryFindAction(indexLoop);
                        Action<EventArgs> newObjValues = newObj.Method;

                        bool t = tryFindAction == newObjValues;
                        bool c = tryFindAction.Equals( newObjValues);
                        if (tryFindAction.Equals( newObjValues))
                        {
                            Debug.Error("Same key and action in event data structure");
                            return;

                            throw new ArgumentException("");
                        }

                        indexLoop++;
                    }

                    _list.Insert(index, newObj);
                }
            }
        }

        public void Add<T>(Action<T> value) where T : notnull, EventArgs, new()
        {
            privateAdd(KeyOffType<T>(), (Action<EventArgs>) value);
        }
        
        public void Add(string key, Action<StringArgs> value)
        {
            privateAdd(key, value);
        }
        
        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains<T>() where T : notnull,  EventList.EventArgs, new()
        {
            return Contains(KeyOffType<T>());
        }
        
        public bool Contains(string key)
        {
            return IndexOfKey(key) >= 0;
        }
        
        public List<EventDataObject<EventList.EventArgs>> Get(string key)
        {
            Range range = GetRange(key);

            return _list.GetRange(range.Start.Value, range.End.Value - range.Start.Value);
        }
        public List<EventDataObject<EventList.EventArgs>> Get<T>()where T : notnull,  EventList.EventArgs, new()
        {
            return Get(KeyOffType<T>());
        }

        public List<EventDataObject<EventList.EventArgs>> GetList()
        {
            return _list;
        }

        private Range GetRange<T>() where T : notnull,  EventList.EventArgs, new()
        {
            string key = KeyOffType<T>();
            return GetRange(key);
        }
        
        private Range GetRange(string key) 
        {
            int index = IndexOfKey(key);
            if (index < 0)
            {
                return new Range(0, 0);
            }

            int indexStart = index;

            int indexEnd = index;

            do
            {
                indexEnd++;
            } while (TryFindKey(indexEnd) == key);

            return new Range(indexStart, indexEnd);
        }
        
        private string KeyOffType<T>() where T : notnull,  EventList.EventArgs, new()
        {
            return new T().GetEventName();
        }

        public void RemoveEventName<T>() where T : notnull,  EventList.EventArgs, new()
        {
            RemoveEventName(KeyOffType<T>());
        }
        
        public void RemoveEventName(string key)
        {
            Range range = GetRange(key);

            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                _list.RemoveAt(range.Start.Value);
            }
        }

        public void Remove(string key, Action<StringArgs> action)
        {
            Remove(new EventDataObject<StringArgs>(key, action));
        }
        
        public void Remove<T>(Action<EventArgs> action)where T : notnull,  EventArgs, new()
        {
            Remove(new EventDataObject<EventArgs>(KeyOffType<T>(), action));
        }

        private void Remove<T>(EventDataObject<T> obj) where T : notnull,  EventArgs, new()
        {
            Range range = GetRange<T>();

            int end = range.End.Value;
            for (int i = range.Start.Value; i < end; i++)
            {
                if (_list[i].Method == obj.Method)
                {
                    _list.RemoveAt(i);
                    i--;
                    end--;
                }
            }
        }

        /*
        * Return the first 
        */
        public int IndexOfKey(string key)
        {
            EventDataObject<EventArgs> obj = new (key, null);
            int index = _list.BinarySearch(obj);

            //Get the first in the array
            while (TryFindKey(index - 1) == obj.Key)
            {
                index--;
            }

            return index;
        }

        private string TryFindKey(int index)
        {
            try
            {
                return _list[index].Key;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }

        private Action<EventArgs> TryFindAction(int index) 
        {
            try
            {
                return _list[index].Method;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }

        private int IndexOfKeyIndex(EventDataObject<EventArgs> obj)
        {
            int index = IndexOfKey(obj.Key);

            //No identic key
            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }
    }
}