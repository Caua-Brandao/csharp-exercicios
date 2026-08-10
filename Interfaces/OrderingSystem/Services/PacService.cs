using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Services
{
    internal class PacService : IShippingService
    {
        public double shipping(double weight)
        {
            if (weight * 5.5 <15)
            {
                return 15;
            }
            else
            {
                return weight * 5.5;
            }
        }
    }
}
