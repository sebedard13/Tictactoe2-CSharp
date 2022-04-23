using System;

namespace TicTacToe2.Controller.Event
{
    public class EventDataObject<T>: IComparable<EventDataObject<T>> where T : notnull,  EventList.EventArgs, new()
    {
        public EventDataObject(string key, Action<T> method) 
        {
            Key = key;
            Method = method;
            
        }

        public string Key { get; }
        
        public string Description { get; }
        
        public string MethodId { get; }

        public Action<T> Method { get;  }

        // public void Invoke()
        // {
        //     Invoke(Array.Empty<string>());
        // }
        public void Invoke(T args)
        {
            Method.Invoke(args);
        }
    
        public int CompareTo(EventDataObject<T>? other)
        {
            return other == null ? 1 : String.Compare(this.Key, other.Key, StringComparison.Ordinal);
        }
        
        public static explicit operator EventDataObject<T>(EventDataObject<EventList.EventArgs> d)
        {
            Action<T> g = d.Method;
            return new EventDataObject<T>(d.Key, g);
        }
    }
}