using System;
using Model;

namespace Core
{
    // wrapper
    // Decorator pattern
    public class CombinedManager : IEventManager
    {
        private readonly IEventManager _inMemoryManager;
        private readonly IEventManager _fileManager;

        public void AddEvent(Event evt)
        {
            _inMemoryManager.AddEvent(evt);
            _fileManager.AddEvent(evt);
        }

        public Event[] GetAllEvents()
        {
            return _inMemoryManager.GetAllEvents();
        }

        public Event[] GetAllEvents(DateTime date)
        {
            throw new NotImplementedException();
        }

        public CombinedManager(IEventManager inMemoryManager, IEventManager fileManager)
        {
            _inMemoryManager = inMemoryManager;
            _fileManager = fileManager;

            foreach (Event evt in _fileManager.GetAllEvents())
            {
                _inMemoryManager.AddEvent(evt);
            }
        }
    }
}