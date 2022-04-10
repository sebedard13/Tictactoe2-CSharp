using System;

namespace TicTacToe2.Controller.Event
{
    public class Event: IComparable<Event>
    {
        public Event(string key, Action<string[]> values)
        {
            Key = key;
            Values = values;
        }

        public string Key { get; }

        public Action<string[]> Values { get; }

        public void Invoke()
        {
            Invoke(Array.Empty<string>());
        }
        public void Invoke(string[] args)
        {
            Values.Invoke(args);
        }
    
        public int CompareTo(Event? other)
        {
            return other == null ? 1 : String.Compare(this.Key, other.Key, StringComparison.Ordinal);
        }
    }
}