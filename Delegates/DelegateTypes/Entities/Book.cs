using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTypes.Entities
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public override string ToString()
        {
            return Title + ", " + Author + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
