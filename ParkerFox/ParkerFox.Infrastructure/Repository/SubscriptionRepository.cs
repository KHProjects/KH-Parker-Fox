using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Magazine;
using ParkerFox.Infrastructure.Data;

namespace ParkerFox.Infrastructure.Repository
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }

        public void Add(Subscription subscription)
        {
            CurrentUnitOfWork.SaveOrUpdate(subscription);
        }

        public Subscription GetById(int subscriptionId)
        {
            return null;
            //return Query(s => s.SubscriptionId == subscriptionId).SingleOrDefault();
        }   
    }
}
