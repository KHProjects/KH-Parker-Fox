using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void UpdateFrom(ChangedBillingAddressEvent changedBillingAddressEvent)
        {
            _street = changedBillingAddressEvent.Street;
            _postCode = changedBillingAddressEvent.PostCode;
        }

        public void Subscribe(Guid publicationId)
        {
            var subscribedToPublication = new SubscribedToPublication();
            Apply(subscribedToPublication);
        }

        private void UpdateFrom(SubscribedToPublication subscribedToPublication)
        {
            
        }
        
    }
}
