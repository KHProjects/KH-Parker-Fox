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
        //private readonly IActiveSessionManager _activeSessionManager;
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepository(/*IActiveSessionManager activeSessionManager*/ IUnitOfWork unitOfWork)
        {
            //_activeSessionManager = activeSessionManager;
            _unitOfWork = unitOfWork;
        }
        
        public void Add(Product product)
        {
            //_activeSessionManager.GetActiveSession().SaveOrUpdate(product);
            _unitOfWork.SaveOrUpdate(product);
        }

        public IEntitySet<Product> GetOnPromotion()
        {            
            return Query(p => p.ProductId > 0);
        }
    }
}
