using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Events;
using System;

namespace MagHag.Subscriptions.Core.Entities
{
    public class Subscriber : Aggregate
    {
        private string _street;
        private string _postCode;

        public void ChangeBillingAddress(string street, string postCode)
        {
            var changedBillingAddressEvent = new ChangedBillingAddressEvent
                {
                    Street = street,
                    PostCode = postCode
                };

            Apply(changedBillingAddressEvent);
        }

        public Subscription Subscribe(Publication publication)
        {
            var subscribedToPublication = new SubscribedToPublication();
            Apply(subscribedToPublication);

            return new Subscription(Guid.NewGuid());
        }

        private void UpdateFrom(ChangedBillingAddressEvent changedBillingAddressEvent)
        {
            _street = changedBillingAddressEvent.Street;
            _postCode = changedBillingAddressEvent.PostCode;
        }

        private void UpdateFrom(SubscribedToPublication subscribedToPublication)
        {
            
        }
    }
}
