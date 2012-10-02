using ParkerFox.Core.Entities.Publication;
using ParkerFox.Core.Entities.Repository.Publication;

using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository.Publication
{
    public sealed class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }
    }
}
