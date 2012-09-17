using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Repository.Ecommerce
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public IEntitySet<Order> GetAll()
        {
            return Query(o => o.OrderId > 0);
        }
    }
}
