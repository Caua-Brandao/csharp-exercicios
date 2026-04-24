using System;
using System.Globalization;
using BankExercice.Entities;

namespace BankExercice
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
                double initialbalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double withdrawlimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(number, holder, initialbalance, withdrawlimit);

                Console.Write("Enter amount for deposit: ");
                double amount = (double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));

                acc.Deposit(amount);
                Console.WriteLine("New balance: " + acc.Balance);

                Console.Write("Enter amount for withdraw: ");
                amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                acc.WithDraw(amount);

                Console.WriteLine("New balance: " + acc.Balance);
            }
            catch (BankException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
