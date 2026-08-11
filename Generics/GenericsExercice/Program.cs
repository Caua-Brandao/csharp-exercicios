using GenericsExercice.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;
using GenericsExercice.Services;

namespace GenericsExercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> Products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=0;i<n;i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
                Products.Add(new Product(vect[0], price));
            }

            Product P = CalculationService.Max(Products);
            Console.WriteLine("Most expensive: " + P.Name + " - " + P.Price);

            List<int> numeros = new List<int> { 3, 4, 5, 6, 7 };
            int maior = CalculationService.Max(numeros);
            Console.WriteLine("The largest number is: " + maior);
        }
    }
}
