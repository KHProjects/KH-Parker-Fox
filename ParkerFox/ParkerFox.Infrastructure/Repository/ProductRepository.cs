using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using ParkerFox.Core.Entities;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public void Add(Product product)
        {
            CurrentUnitOfWork.SaveOrUpdate(product);
        }

        public IEntitySet<Product> GetOnPromotion()
        {            
            return Query(p => p.ProductId>0);
        }

        public IEntitySet<Product> GetInCategory(int categoryId)
        {
            return Query(p=>p.ProductId>0);
        }
    }
}
