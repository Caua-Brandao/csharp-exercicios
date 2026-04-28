using ConferenceManager.Entities.Exceptions;
using System;
using System.Collections.Generic;

namespace ConferenceManager.Entities
{
    internal class Event
    {
        public string name { get; private set; }
        public DateTime startdate { get; private set; }
        public DateTime endDate { get; private set; }
        public int maxcapacity { get; private set; }
        public EventStatus status { get; private set; }
        public List<Participant> participants { get; private set; }

        public Event(string name, DateTime start, DateTime end, int capacity)
        {
            this.name = name;
            this.startdate = start;
            this.endDate = end;
            this.maxcapacity = capacity;
            this.participants = new List<Participant>();
        }
        public void AddParticipant(Participant p)
        {
            if (participants.Count == maxcapacity)
            {
                throw new EventException("Evento lotado.");
            }
            else if (status == EventStatus.Closed)
            {
                throw new EventException("Evento encerrado");
            }
            foreach (Participant part in participants)
            {
                if(part.Email == p.Email)
                {
                    throw new EventException("Email já cadastrado");
                }
            }
            participants.Add(p);
        }
        public void RemoveParticipant(string email)
        {
            Participant p = GetParticipantByEmail(email);
            if (p == null)
            {
                throw new EventException("Participant not found");
            }
            participants.Remove(p);
        }
        public Participant GetParticipantByEmail(string email)
        {
            Participant found = participants.Find(p => p.Email == email);
            return found;
        }

        public void ListAllParticipants()
        {
            participants.ForEach(part => Console.WriteLine(part.GetInfo()));
        }
        public void ListSpeakers()
        {
            foreach (Participant part in participants)
            {
                if (part is Speaker)
                {
                    Console.WriteLine(part.GetInfo());
                }
            }
        }
        public void ListAttendees()
        {
            foreach (Participant part in participants)
            {
                if (part is Attendee)
                {
                    Console.WriteLine(part.GetInfo());
                }
            }
        }
        public void ListOrganizers()
        {
            foreach (Participant part in participants)
            {
                if (part is Organizer)
                {
                    Console.WriteLine(part.GetInfo());
                }
            }
        }
        public int GetDuration()
        {
            return (int)(endDate - startdate).TotalDays;
        }
        public double GetTotalRevenue()
        {
            double sum = 0;
            foreach(Participant part in participants)
            {
                sum += part.GetFee();
            }
            return sum;
        }
        public bool IsFull()
        {
            if (participants.Count >= maxcapacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void StartEvent()
        {
            if (status == EventStatus.Open || status == EventStatus.Closed || status == EventStatus.InProgress)
            {
                throw new EventException("Evento já iniciado.");
            }
            else if(DateTime.Now < startdate)
            {
                throw new EventException("Data de início ainda não chegou.");
            }
            else
            {
                status = EventStatus.InProgress;
            }
        }
        public void CloseEvent()
        {
            if (status != EventStatus.InProgress)
            {
                throw new EventException("Evento não está em andamento.");
            }
            status = EventStatus.Closed;
        }
        public string GetEventSummary()
        {
            return $"Event: {name}\nDuration: {GetDuration()}\nStatus: {status}\nParticipants: {participants.Count}/{maxcapacity}" +
                $"\nTotal revenue: R$ {GetTotalRevenue()}";
        }
    }
}
