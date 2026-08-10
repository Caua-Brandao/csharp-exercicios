using OrderingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Services
{
    internal class SedexService : IShippingService, ITrackable
    {
        public double shipping(double weight)
        {
            if (weight *12 <20)
            {
                return 20;
            }
            else
            {
                return weight * 12;
            }
        }

        public string TrackingCode(Order order)
        {
            return "SD" + order.Number + "BR";
        }
    }
}
