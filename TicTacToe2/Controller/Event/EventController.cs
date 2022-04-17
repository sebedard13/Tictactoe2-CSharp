using System;
using System.Collections.Generic;
using TicTacToe2.Utils.Debug;
using TicTacToe2.View;

namespace TicTacToe2.Controller.Event
{
    public class EventController
    {
        private readonly EventDataStruct _eventList = new EventDataStruct();
        
        public EventController()
        {
            Listen("help", strings =>
            {
                List<Event> list = _eventList.GetList();
                foreach (Event eventItem in list)
                {
                    ConsoleInterface.WriteLine(eventItem.Key);
                }
            });
        }

        public void Listen(string eventName, Action<string[]> action)
        {
            eventName = CheckValidEvent(eventName, "Listen to");
            _eventList.Add(eventName, action);
        }

        public void Call(string eventName)
        {
            Call(eventName, Array.Empty<string>());
        }

        public void Call(string eventName, string[] args)
        {
            eventName = CheckValidEvent(eventName, "Call");
            List<Event> events = _eventList.Get(eventName);
            if (events.Count <= 0)
            {
                Debug.Warning("Event " + eventName + " was not found");
            }

            foreach (Event @event in events)
            {
                @event.Invoke(args);
            }
        }

        public void Remove(string eventName, Action<string[]> action)
        {
            _eventList.Remove(eventName, action);
        }

        public void Remove(string eventName)
        {
            _eventList.RemoveEventName(eventName);
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