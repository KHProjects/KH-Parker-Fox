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
        private string _title;

        public Publication(Guid id, string title)
        {
            Apply(new PublicationCreated(id, title));
        }

        private void UpdateFrom(PublicationCreated publicationCreated)
        {
            Id = publicationCreated.PublicationId;
            _title = publicationCreated.Title;
        }
    }
}
