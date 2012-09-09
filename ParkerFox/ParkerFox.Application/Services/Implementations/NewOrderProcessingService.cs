using ParkerFox.Application.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Application.Services.Implementations
{
    public class NewOrderProcessingService : INewOrderProcessingService
    {
        public IEnumerable<Order> GetOrders()
        {
            return new List<Order>
                {
                    new Order(),
                    new Order()
                };
        }
    }
}
