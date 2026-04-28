using ConferenceManager.Entities.Exceptions;
using System;
using System.Collections.Generic;

namespace ConferenceManager.Entities
{
    internal class EventManager
    {
        public List<Event> events { get; private set; }

        public EventManager()
        {
            events = new List<Event>();
        }

        public void AddEvent(Event e)
        {
            events.Add(e);
        }

        public void RemoveEvent(string name)
        {
            Event ev = null;
            foreach (Event e in events)
            {
                if (e.name == name)
                {
                    ev = e;
                    break;
                }
            }

            if (ev != null)
            {
                events.Remove(ev);
                return;
            }

            throw new EventException("Event not found to removal.");
        }
        public Event FindEvent(string name)
        {
            foreach(Event e in events)
            {
                if (e.name == name)
                {
                    return e;
                }
            }
            throw new EventException("Evento não encontrado.");
        }
        public void ListAllEvents()
        {
            foreach(Event e in events)
            {
                Console.WriteLine(e.GetEventSummary());
            }
        }
        public void ListEventsbyStatus(EventStatus status)
        {
            foreach(Event e in events)
            {
                if (e.status == status)
                {
                    Console.WriteLine(e.GetEventSummary());
                }
            }
        }
        public int GetTotalParticipants()
        {
            int sum = 0;
            foreach(Event e in events)
            {
                sum += e.participants.Count; 
            }
            return sum;
        }
        public double GetTotalRevenue()
        {
            double sum = 0;
            foreach(Event e in events)
            {
                sum += e.GetTotalRevenue();
            }
            return sum;
        }
    }
}
