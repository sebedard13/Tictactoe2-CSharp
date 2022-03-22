using System;

namespace TicTacToe2.Controller
{
    public class EventDataStructObject: IComparable<EventDataStructObject>
    {
        private readonly string _key;

        private readonly Action<string[]> _values;

        public EventDataStructObject(string key, Action<string[]> values)
        {
            _key = key;
            _values = values;
        }

        public string Key => _key;

        public Action<string[]> Values => _values;
    
        public int CompareTo(EventDataStructObject? other)
        {
            if (other == null)
                return 1;
            return String.Compare(this.Key, other.Key, StringComparison.Ordinal);
        }
    }
}