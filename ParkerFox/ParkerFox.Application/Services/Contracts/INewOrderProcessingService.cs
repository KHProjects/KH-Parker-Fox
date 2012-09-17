using ParkerFox.Core.Entities.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Application.Services.Contracts
{
    [ServiceContract]
    public interface INewOrderProcessingService
    {
        [OperationContract]
        IEnumerable<Order> GetOrders();
    }
}
