using System;

namespace OrderingSystem.Entities
{
    internal class Product : IComparable<Product>
    {
        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }


        public int CompareTo(Product other)
        {
            int price = other.Price.CompareTo(Price);

            if (price!=0)
            {
                return price;
            }
            else
            {
                return Name.CompareTo(other.Name);
            }
        }
    }
}
