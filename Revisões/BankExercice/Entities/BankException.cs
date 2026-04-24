using System;

namespace BankExercice.Entities
{
    internal class BankException : ApplicationException
    {
        public BankException(string message): base(message)
        {
        }
    }
}
