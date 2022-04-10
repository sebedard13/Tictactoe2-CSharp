using System;
using System.Collections.Generic;
using TicTacToe2.Utils.Debug;

namespace TicTacToe2.Controller.Event
{
    public class EventDataStruct
    {
        private readonly List<Event> _list = new();

        public int Count
            => _list.Count;

        public bool DoubleAction { get; set; } = false;

        public void Add(string key, Action<string[]> value)
        {
            Event newObj = new Event(key, value);

            if (DoubleAction)
            {
                int index = IndexOfKeyIndex(newObj);

                _list.Insert(index, newObj);
            }
            else
            {
                int index = IndexOfKey(newObj);

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
                        if (TryFindAction(indexLoop) == newObj.Values)
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

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(string key)
        {
            return IndexOfKey(key) >= 0;
        }

        public List<Event> Get(string key)
        {
            Range range = GetRange(key);

            return _list.GetRange(range.Start.Value, range.End.Value - range.Start.Value);
        }

        public List<Event> GetList()
        {
            return _list;
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

        public void RemoveEventName(string key)
        {
            Range range = GetRange(key);

            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                _list.RemoveAt(range.Start.Value);
            }
        }

        public void Remove(string key, Action<string[]> action)
        {
            Remove(new Event(key, action));
        }

        private void Remove(Event obj)
        {
            Range range = GetRange(obj.Key);

            int end = range.End.Value;
            for (int i = range.Start.Value; i < end; i++)
            {
                if (_list[i].Values == obj.Values)
                {
                    _list.RemoveAt(i);
                    i--;
                    end--;
                }
            }
        }

        public int IndexOfKey(string key)
        {
            Event sampleObj = new Event(key, null);
            return IndexOfKey(sampleObj);
        }

        /*
         * Return the first 
         */
        private int IndexOfKey(Event obj)
        {
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

        private Action<string[]> TryFindAction(int index)
        {
            try
            {
                return _list[index].Values;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }

        private int IndexOfKeyIndex(Event obj)
        {
            int index = IndexOfKey(obj);

            //No identic key
            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }
    }
}