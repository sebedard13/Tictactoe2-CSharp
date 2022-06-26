using System;
using System.Collections.Generic;
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
                List<EventDataObject> list = _eventList.GetAll();
                foreach (EventDataObject eventItem in list)
                {
                    ConsoleInterface.WriteLine(eventItem.Key + " - " + eventItem.Description);
                }
            });
        }

        public void Listen<T>(Action<T> action)where T : notnull,  EventArgs, new()
        {
            _eventList.Add(EventDataObjectUtils.Create(action));
        }
        
        public void Listen(string eventName, Action<StringArgs> action)
        {
            eventName = CheckValidEvent(eventName, "Listen to");
            _eventList.Add(EventDataObjectUtils.Create(eventName, action));
        }

        public void Call<T>(T args) where T : notnull,  EventArgs, new()
        {
            String eventName = KeyOffType<T>();
            eventName = CheckValidEvent(eventName, "Call");
            List<EventDataObject> events = _eventList.Get(eventName);
            if (events.Count <= 0)
            {
                Debug.Warning("EventArgs " + eventName + " was not found");
            }
            
            foreach (EventDataObject @event in events) 
            {
               @event.Invoke(args);
            }
        }
        
        public void Call(string eventName, string[] args)
        {
            eventName = CheckValidEvent(eventName, "Call");
            List<EventDataObject> events = _eventList.Get(eventName);
            if (events.Count <= 0)
            {
                Debug.Warning("EventArgs " + eventName + " was not found");
            }

            StringArgs eventArgs = new StringArgs();
            eventArgs.setArguments(args);
            foreach (EventDataObject @event in events) 
            {
                @event.Invoke(eventArgs);
            }
        }

        public void Remove(string eventName, Action<StringArgs> action)
        {
            _eventList.Remove(EventDataObjectUtils.Create(eventName, action));
        }

        public void Remove<T>() where T : notnull,  EventArgs, new()
        {
            _eventList.RemoveEventName(KeyOffType<T>());
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
        
        private string KeyOffType<T>() where T : notnull,  EventArgs, new()
        {
            return new T().GetEventName();
        }

    }
}