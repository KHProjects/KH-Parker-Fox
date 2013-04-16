using MagHag.Core.Entities;
using MagHag.Subscriptions.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Entities
{
    public class Publication : Aggregate
    {
        private bool _isActive = false;
        private string _title;
        private long _ActivatedBy;

        public Publication(Guid id, string title)
        {
            Apply(new PublicationCreated(id, title));
        }

        public void Activate()
        {
            if (!_isActive)
            {
                Apply(new PublicationActivated());
            }
            else
            {
                throw new InvalidOperationException("you can not activate an active publication");
            }
        }

        private void UpdateFrom(PublicationCreated publicationCreated)
        {
            Id = publicationCreated.PublicationId;
            _title = publicationCreated.Title;
        }

        private void UpdateFrom(PublicationActivated pub)
        {
            _isActive = true;
            _ActivatedBy = pub.UserId;
        }
    }
}
