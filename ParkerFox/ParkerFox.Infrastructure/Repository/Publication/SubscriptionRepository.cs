using System.Collections.Generic;
using System.Linq;
using ParkerFox.Core.Entities.Publication;
using ParkerFox.Core.Entities.Publication.Specifications;
using ParkerFox.Core.Entities.Repository.Publication;
using ParkerFox.Core.Specifications;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository.Publication
{
    public sealed class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Subscription> GetActive()
        {
            return Query(new ActiveSubscription());
        }
    }
}
