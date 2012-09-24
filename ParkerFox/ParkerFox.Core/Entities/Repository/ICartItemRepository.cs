using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Core.Entities.Repository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        IEntitySet<CartItem> GetCurrent(string identifier);
    }
}
