using ExceptionExercise.Entities;
using ExceptionExercise.Entities.Exceptions;
using System;

namespace ExceptionExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data: ");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine());
                Console.Write("Withdraw Limit: ");
                double withdrawlimit = double.Parse(Console.ReadLine());

                Account acc = new Account(number, holder, balance, withdrawlimit);

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine());
                acc.Withdraw(amount);
                Console.WriteLine("New balance: " + acc.Balance);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Withdraw Error: " + e.Message);
            }
        }
    }
}
