using System;
using DelegateTest.Services;
using System.Globalization;

namespace DelegateTest
{
    internal class Program
    {
        delegate void PricingHandler(double p);
        delegate void NotificationHandler(string msg);
        static void Main(string[] args)
        {
            Console.Write("Enter message: ");
            string message = Console.ReadLine();
            NotificationHandler nh = NotificationService.LogToConsole;
            nh += NotificationService.SendEMail;
            nh += NotificationService.SendSms;

            nh(message);

            Console.WriteLine("\nAfter removing SMS\n");

            nh -= NotificationService.SendSms;

            nh(message);

            PricingHandler ph = PricingService.ApplyDiscount;
            ph += PricingService.ApplyTax;
            Console.Write("\n\nEnter value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            ph(value);
        }
    }
}
