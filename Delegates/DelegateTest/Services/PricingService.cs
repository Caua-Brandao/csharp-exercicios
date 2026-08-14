using System;


namespace DelegateTest.Services
{
    static class PricingService
    {
        static public void ApplyDiscount(double amount)
        {
            double FinalValue = amount -= (amount * 0.10);
            Console.WriteLine("With discount: " + FinalValue);
        }

        static public void ApplyTax(double amount)
        {
            double finalValue = amount += (amount * 0.15);
            Console.WriteLine("With tax: " + finalValue);
        }
    }
}
