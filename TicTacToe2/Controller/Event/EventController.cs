using System;
using System.Collections.Generic;
using System.Net;
using TicTacToe2.Controller.Event.EventList;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;
using EventArgs = TicTacToe2.Controller.Event.EventList.EventArgs;

namespace TicTacToe2.Controller.Event
{
    public class EventController
    {
        private readonly EventDataStruct _eventList = new EventDataStruct();
        
        public EventController()
        {
            Listen("help", strings =>
            {
                List<EventDataObject<EventList.EventArgs>> list = _eventList.GetList();
                foreach (EventDataObject<EventList.EventArgs> eventItem in list)
                {
                    ConsoleInterface.WriteLine(eventItem.Key);
                }
            });
        }

        public void Listen<T>(Action<T> action)where T : notnull,  EventList.EventArgs, new()
        {
            T a = new T();
            a.GetEventName();
            _eventList.Add<T>(action);
        }
        
        public void Listen(string eventName, Action<StringArgs> action)
        {
            eventName = CheckValidEvent(eventName, "Listen to");
            _eventList.Add(eventName, action as Action<EventArgs>);
        }

        // public void Call(string eventName)
        // {
        //     Call(eventName, Array.Empty<string>());
        // }

        public void Call<T>(T args) where T : notnull,  EventList.EventArgs, new()
        {
            String eventName = new T().GetEventName();
            eventName = CheckValidEvent(eventName, "Call");
            List<EventDataObject<EventList.EventArgs>> events = _eventList.Get<T>();
            if (events.Count <= 0)
            {
                Debug.Warning("EventArgs " + eventName + " was not found");
            }
            
            foreach (EventDataObject<EventList.EventArgs> @event in events) 
            {
               @event.Invoke(args);
            }
        }
        
        public void Call(string eventName, string[] args)
        {
            eventName = CheckValidEvent(eventName, "Call");
            List<EventDataObject<EventList.EventArgs>> events = _eventList.Get(eventName);
            if (events.Count <= 0)
            {
                Debug.Warning("EventArgs " + eventName + " was not found");
            }

            StringArgs eventArgs = new StringArgs(args);
            foreach (EventDataObject<EventList.EventArgs> @event in events) 
            {
                @event.Invoke(eventArgs);
            }
        }

        public void Remove(string eventName, Action<EventList.EventArgs> action)
        {
            _eventList.Remove(eventName, action);
        }

        public void Remove<T>() where T : notnull,  EventList.EventArgs, new()
        {
            _eventList.RemoveEventName<T>();
        }

        private string CheckValidEvent(string eventName, string functionName)
        {
            string lowerEventName = eventName.ToLowerInvariant();
            if (eventName != lowerEventName)
            {
                Debug.Warning(functionName+" event "+eventName+" is not lowercase");
            }

            return lowerEventName;
        }
    }
}