using System;
using Model;

namespace Core
{
    public interface IEventManager
    {
        void AddEvent(Event evt);

        Event[] GetAllEvents();

        Event[] GetAllEvents(DateTime date);
    }
}