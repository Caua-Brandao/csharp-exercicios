using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Entities
{
    internal class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct()
        {
        }
        public UsedProduct(string name, double price, DateTime manufacturedate) : base(name, price)
        {
            this.ManufactureDate = manufacturedate;
        }

        public override string PriceTag()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" (used) $ ");
            sb.Append(Price);
            sb.Append(" (Manufacture date: ");
            sb.Append(ManufactureDate.ToString("dd/MM/yyyy")+")");
            return sb.ToString();
        }
    }
}
