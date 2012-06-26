using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Repository
{
    public interface IProductRepository : IRepository<ParkerFox.Core.Entities.Ecommerce.Product>
    {
        IEntitySet<ParkerFox.Core.Entities.Ecommerce.Product> GetOnPromotion();
    }
}
