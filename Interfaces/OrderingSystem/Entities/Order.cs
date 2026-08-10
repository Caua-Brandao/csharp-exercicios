using System;
using System.Collections.Generic;
using System.Globalization;

namespace OrderingSystem.Entities
{
    internal class Order
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public double ShippingCost { get; set; }

        public Order(int number, DateTime date)
        {
            Number = number;
            Date = date;
        }

        public double TotalWeight()
        {
            double sum = 0;
            foreach(Product product in Products)
            {
                sum += product.Weight;
            }
            return sum;
        }

        public double Total()
        {
            double sum = 0;
            foreach (Product product in Products)
            {
                sum += product.Price;
            }
            return sum;
        }
    }
}
