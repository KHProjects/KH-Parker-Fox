using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Core.Entities.Repository.Publication
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Subscription GetByUserId(int userId);
    }
}
