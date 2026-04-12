using OrderList.Entities;
using OrderList.Entities.Enums;
using System;
using System.Globalization;

namespace OrderList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status;
            Enum.TryParse(Console.ReadLine(), out status);

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(quantity, productPrice, product);
                order.AddItem(item);
            }
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}