using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Core
{
    public class InMemoryManager : IEventManager
    {
        private readonly List<Event> _events;
        
        public void AddEvent(Event evt)
        {
            _events.Add(evt);
        }

        public Event[] GetAllEvents()
        {
            return _events.ToArray();
        }

        public Event[] GetAllEvents(DateTime date) // 23.04.2020 14:33:15
        {
            var startDate = new DateTime(date.Year, date.Month, date.Day); // 23.04.2020 00:00:00
            var endDate = startDate.AddDays(1); // 24.04.2020 00:00:00

            // LINQ - C# // Streams - Java
            
            return _events.Where(x => x.EvtTime >= startDate && x.EvtTime < endDate).ToArray();
        }

        public InMemoryManager()
        {
            _events = new List<Event>();
        }
    }
}