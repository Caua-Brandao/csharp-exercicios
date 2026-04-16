using Products.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());


            for (int i =1;i<=n;i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i): ");
                char v = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());
                if (v == 'c')
                {
                    Product p = new Product(name, price);
                    products.Add(p);
                }
                else if (v == 'i')
                {
                    Console.Write("Custom fee: ");
                    double customfree = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    ImportedProduct ip = new ImportedProduct(name, price, customfree);
                    ip.TotalPrice(customfree);
                    products.Add(ip);
                }
                else if (v == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufacturedate = DateTime.Parse(Console.ReadLine());
                    UsedProduct up = new UsedProduct(name, price, manufacturedate);
                    products.Add(up);
                }
            }

            Console.WriteLine("PRICE TAGS: ");
            foreach (Product prod in products)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
