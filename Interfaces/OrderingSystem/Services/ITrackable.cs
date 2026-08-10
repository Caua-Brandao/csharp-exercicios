using OrderingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Services
{
    internal interface ITrackable
    {
        string TrackingCode(Order order);
    }
}
