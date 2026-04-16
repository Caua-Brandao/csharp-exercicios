using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Entities
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public virtual string PriceTag()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" $ " + Price);
            return sb.ToString();
        }
    }
}
