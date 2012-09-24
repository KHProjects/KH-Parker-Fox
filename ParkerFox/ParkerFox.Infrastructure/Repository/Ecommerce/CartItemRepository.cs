using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository.Ecommerce
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork){}

        public IEntitySet<CartItem> GetCurrent(string identifier)
        {
            throw new System.NotImplementedException();
        }
    }
}
