using OrderingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Services
{
    internal class OrderService
    {
        private  IShippingService _shippingService;

        public OrderService(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public void ProcessOrder(Order order)
        {
            order.Products.Sort();
            order.ShippingCost = _shippingService.shipping(order.TotalWeight());
        }
    }
}
