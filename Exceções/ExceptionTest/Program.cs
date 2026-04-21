using ExceptionTest.Entities;
using ExceptionTest.Entities.Exceptions;
using System;  

namespace ExceptionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room numbwer: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out (dd/MM/yyyy): ");
                DateTime checkout = DateTime.Parse(Console.ReadLine());

                Reservation res = new Reservation(number, checkin, checkout);
                Console.WriteLine("Reservation: " + res);

                Console.WriteLine("Enter data to update reservation: ");
                Console.Write("Check-in date: ");
                checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date: ");
                checkout = DateTime.Parse(Console.ReadLine());
                res.UpdateDates(checkin, checkout);
                Console.WriteLine("Reservation: " + res);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error in reservation: " + e.Message);
            }
            
        }
    }
}
