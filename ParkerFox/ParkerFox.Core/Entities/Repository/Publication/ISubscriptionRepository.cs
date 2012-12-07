using ParkerFox.Core.Entities.Publication;
using System.Collections.Generic;
using ParkerFox.Core.Specifications;

namespace ParkerFox.Core.Entities.Repository.Publication
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        IEnumerable<Subscription> GetActive();
    }
}
