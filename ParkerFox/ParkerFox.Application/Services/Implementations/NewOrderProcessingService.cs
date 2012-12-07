using ParkerFox.Application.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.IoC.Wcf;

namespace ParkerFox.Application.Services.Implementations
{
    [NinjectServiceBehaviour]
    public class NewOrderProcessingService : INewOrderProcessingService
    {
        private readonly IOrderRepository _orderRepository;

        public NewOrderProcessingService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll().All();
        }
    }
}
