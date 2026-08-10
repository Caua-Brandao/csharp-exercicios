using System;
using OrderingSystem.Entities;
using System.Globalization;
using OrderingSystem.Services;

namespace OrderingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ORDER SUMMARY");
            Console.Write("Order number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            Order order = new Order(number, date);

            Console.Write("How many products? ");
            int n = int.Parse(Console.ReadLine());
            for (int i=1;i<=n;i++)
            {
                Console.Write($"Product {i} name: ");
                string name = Console.ReadLine();
                Console.Write($"Product {i} price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write($"Product {i} weight: ");
                double weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                order.Products.Add(new Product(name, price, weight));
                Console.WriteLine();
            }

            IShippingService ServiceType = new SedexService();
            OrderService os = new OrderService(ServiceType);

            os.ProcessOrder(order);

            foreach (Product prod in order.Products)
            {
                Console.WriteLine($"{prod.Name} - {prod.Price.ToString("F2")} - ({prod.Weight.ToString("F1")} kg)");
            }

            Console.WriteLine("Total weight - " + order.TotalWeight().ToString("F1") + " kg");
            Console.WriteLine("Products Total - " + order.Total().ToString("F2"));

            Console.WriteLine("Shipping cost - " + order.ShippingCost.ToString("F2"));
            Console.WriteLine("ORDER TOTAL - " + (order.ShippingCost + order.Total()).ToString("F2")); 

            if (ServiceType is ITrackable itrack)
            {
                Console.WriteLine("Tracking code: " + itrack.TrackingCode(order));
            }
        }
    }
}
