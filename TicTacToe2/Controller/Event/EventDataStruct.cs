using System;
using System.Collections.Generic;
using TicTacToe2.Utils.Debug;
using EventArgs = TicTacToe2.Controller.Event.EventList.EventArgs;

namespace TicTacToe2.Controller.Event
{
    
    public class EventDataStruct
    {
        private readonly List<EventDataObject> _list = new(); 

        public int Count
            => _list.Count;

        public bool DoubleAction { get; set; } = false;
        

        public void Add(EventDataObject newObj)
        {
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
                        if (TryMethodId(indexLoop) == newObj.MethodId)
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
        
        public List<EventDataObject> Get(string key)
        {
            Range range = GetRange(key);

            return _list.GetRange(range.Start.Value, range.End.Value - range.Start.Value);
        }

        public List<EventDataObject> GetAll()
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
        
        public void Remove(EventDataObject obj)
        {
            Range range = GetRange(obj.Key);

            int end = range.End.Value;
            for (int i = range.Start.Value; i < end; i++)
            {
                if (TryMethodId(i) == obj.MethodId)
                {
                    _list.RemoveAt(i);
                    i--;
                    end--;
                }
            }
        }

        /*
        * Because a binary search can find an object from the start and the end of the list
         * we check to actually give the first of the list by going back
        */
        public int IndexOfKey(string key)
        {
            int index = _list.BinarySearch(EventDataObjectUtils.CreateEmpty(key));

            //Get the first in the array
            while (TryFindKey(index - 1) == key)
            {
                index--;
            }

            return index;
        }

        private int IndexOfKeyIndex(EventDataObject obj)
        {
            int index = IndexOfKey(obj.Key);

            //No identic key
            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }
        
        
        //********
        //TryFind.... suppress ArgumentOutOfRangeException if out of index
        
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
        
        private string TryMethodId(int index)
        {
            try
            {
                return _list[index].MethodId;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }
    }
}