using System;

namespace Model
{
    public class Event
    {
        public Guid Id { get; }

        public string Title { get; }

        public string Description { get; }

        public DateTime EvtTime { get; }

        public override string ToString()
        {
            return $"Event '{Title}' on {EvtTime}";
        }

        public Event(Guid id, string title, string description, DateTime evtTime)
        {
            Id = id;
            Title = title;
            Description = description;
            EvtTime = evtTime;
        }
    }
}