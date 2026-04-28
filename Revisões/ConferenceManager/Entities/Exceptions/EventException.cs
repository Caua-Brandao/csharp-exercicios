using System;

namespace ConferenceManager.Entities.Exceptions
{
    internal class EventException : ApplicationException
    {
        public EventException(string message) : base(message)
        {
        }
    }
}
