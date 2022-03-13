using System;
using System.Collections.Generic;
using TicTacToe2.View;

namespace Script
{
    public class EventController
    {
        private static EventController thisInstance = null;
        private static readonly object padlock = new object();

        private SortedDictionary<string, Action<string[]>> eventList = new SortedDictionary<string, Action<string[]>>();

        EventController()
        {
        }

        private static EventController Instance
        {
            get
            {
                if (thisInstance == null)
                {
                    lock (padlock)
                    {
                        if (thisInstance == null)
                        {
                            thisInstance = new EventController();
                        }
                    }
                }
                return thisInstance;
            }
        }


        public static void ListenEvent(string eventName, Action<string[]> action)
        {
            Instance.eventList.Add(eventName, action);
        }

        public static void CallEvent(string eventName)
        {
            CallEvent(eventName, new string[]{});
        }

        public static void CallEvent(string eventName, string[] args)
        {
            try
            {
                Action<string[]> action = Instance.eventList[eventName];
                action.Invoke(args);
            }
            catch (KeyNotFoundException e)
            {
                Debug.WriteWarning("Event "+eventName+" was not found");
            }
        }
        
        public static void RemoveEvent(string eventName, Action<string[]> action)
        {
            RemoveEventName(eventName);
        }
        
        public static void RemoveEventName(string eventName)
        {
            Instance.eventList.Remove(eventName);
        }
    }
}