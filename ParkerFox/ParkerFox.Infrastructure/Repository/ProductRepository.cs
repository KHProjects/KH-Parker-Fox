using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using ParkerFox.Core.Entities;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IActiveSessionManager _activeSessionManager;

        public ProductRepository(IActiveSessionManager activeSessionManager)
        {
            _activeSessionManager = activeSessionManager;
        }
        
        public void Add(Product product)
        {
            _activeSessionManager.GetActiveSession().SaveOrUpdate(product);            
        }

        public IEnumerable<Product> GetOnPromotion()
        {
            return Query(p => p.ProductId == 1);
        }
    }
}
