using ParkerFox.Core.ApplicationServices.Publication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Publication;
using ParkerFox.Core.Entities.Repository.Publication;

namespace ParkerFox.Application.Services.Publication
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionServices(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Subscription GetCurrent()
        {
            return _subscriptionRepository.GetByUserId(1);
        }
    }
}
