using System.Linq;
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

        public Subscription GetByUserId(int userId)
        {
            return Query(x => x.SubscriptionId > 0).Page(0, 1).FirstOrDefault();
        }
    }
}
