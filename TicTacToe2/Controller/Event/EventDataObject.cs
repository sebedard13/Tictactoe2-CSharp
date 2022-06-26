using System;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;
using EventArgs = TicTacToe2.Controller.Event.EventList.EventArgs;

namespace TicTacToe2.Controller.Event
{
    public class EventDataObject: IComparable<EventDataObject>
    {
        public EventDataObject(string key, string description, string methodId, Action<EventArgs> method)
        {
            Key = key;
            Description = description;
            MethodId = methodId;
            Method = method;
        }

        public string Key { get; }
        
        public string Description { get; }
        
        public string MethodId { get; }

        public Action<EventArgs> Method { get; set; }

        // public void Invoke()
        // {
        //     Invoke(Array.Empty<string>());
        // }
        public void Invoke(EventArgs args)
        {
            Method.Invoke(args);
        }
    
        public int CompareTo(EventDataObject? other)
        {
            return other == null ? 1 : String.Compare(this.Key, other.Key, StringComparison.Ordinal);
        }
        
        // public static explicit operator EventDataObject(EventDataObject d)
        // {
        //     Action<T> g = d.Method;
        //     return new EventDataObject<T>(d.Key, g);
        // }
    }
    
    public static class EventDataObjectUtils{

        public static EventDataObject CreateEmpty(string key)
        {
            return new EventDataObject(key, null, null, null);
        }
        
        public static EventDataObject Create<T>(Action<T> method) where T : notnull, EventArgs, new ()
        {
            T currentClass = new T();
            
            string key = currentClass.GetEventName();
            string description = currentClass.GetEventDescription();
            string methodId = method.Method.ToString();
            
            Action<EventArgs> objectMethod = arg => { 
                T currentEvent = new T();
                StringArgs currentArgs = (StringArgs) arg;
                try{
                    currentEvent.setArguments(currentArgs.Args);
                    method.Invoke(currentEvent); 
                }
                catch(ArgumentException e){
                 ViewController.BadEvent(e);   
                }
                
                };
           
            return new EventDataObject(key, description, methodId, objectMethod);
        }
        
        public static EventDataObject Create(string key, Action<StringArgs> method)
        {
            string description = StringArgs.EventDescription;
            string methodId = method.Method.ToString();
            
            Action<EventArgs> objectMethod = args => { method.Invoke((StringArgs)args); };
           
            return new EventDataObject(key, description, methodId, objectMethod);
        }
        
    }
}