using LinqExercice1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

namespace LinqExercice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\cauab\OneDrive\Desktop\Products.csv";
            List<Product> products = new List<Product>();
            try
            {
                using (StreamReader sr = new StreamReader(sourcePath))
                {
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');
                        string name = data[0];
                        double price = double.Parse(data[1], CultureInfo.InvariantCulture);
                        products.Add(new Product(name, price));
                    }
                }
                var averagePrice = products.Average(p => p.Price);
                Console.WriteLine(averagePrice.ToString("F2", CultureInfo.InvariantCulture));

                var names = products.Where(p => p.Price < averagePrice).OrderByDescending(p => p.Name).Select(p => p.Name);
                foreach(var name in names)
                {
                    Console.WriteLine(name);
                }
            }
            catch(DirectoryNotFoundException d)
            {
                Console.WriteLine("Error, an error occurred: " + d.Message);
            }
        }
    }
}
