using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Core.Entities.Repository
{
    public interface IProductRepository : IRepository<ParkerFox.Core.Entities.Ecommerce.Product>
    {
        IEntitySet<ParkerFox.Core.Entities.Ecommerce.Product> GetOnPromotion();
        Product GetById(int productId);
    }
}
