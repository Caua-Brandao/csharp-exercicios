using System;


namespace OrderingSystem.Entities
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
