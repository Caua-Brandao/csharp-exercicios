using DelegateTypes.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTypes
{
    internal class Program
    {
        static double value;
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Clean Code", "Robert Martin", 120.00));
            books.Add(new Book("Domain-Driven Design", "Eric Evans", 260.00));
            books.Add(new Book("The Pragmatic Programmer", "Anfrew Hunt", 180.00));
            books.Add(new Book("Refactoring", "Martin Fowler", 210.00));
            books.Add(new Book("Head First Design Patterns", "Eric Freeman", 95.00));

            foreach (var item in books)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nEnter the value: ");
            value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Possible solution
            // books.RemoveAll(b => b.Price >= value);


            books.RemoveAll(PriceTest);
            Console.WriteLine("Remaining books:\n");
            
            foreach (var item in books)
            {
                Console.WriteLine(item);
            }

            Action<Book> discount = b => b.Price -= b.Price * 0.1;
            books.ForEach(discount);
            Console.WriteLine("\nAfter 10% discount:\n");
            foreach (var item in books)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nCatalog labels:");

            List<string> labels = books.Select(b => b.Title.ToUpper() + " (" + b.Author + ")").ToList();
            Console.WriteLine(string.Join("\n", labels));
        }
        static public bool PriceTest(Book b)
        {
            return b.Price >= value;
        }

    }
}
