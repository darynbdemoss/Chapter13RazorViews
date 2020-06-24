using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter13RazorViews;
using Chapter13RazorViews.Models;

namespace Chapter13RazorViews.Data
{
    public class EventsData
    {
        static private Dictionary<int, Event> Events = new Dictionary<int, Event>();
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        public static Event GetById(int id)
        {
            return Events[id];
        }

        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        
    }
}
