using System;
using ParkerFox.Core.Entities.Magazine;
namespace ParkerFox.Infrastructure.Repository
{
    public interface ISubscriptionRepository
    {
        void Add(Subscription subscription);
        Subscription GetById(int subscriptionId);
    }
}
