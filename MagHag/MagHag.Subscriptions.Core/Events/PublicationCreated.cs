using System;
using MagHag.Core.Messaging.EventSourcing;

namespace MagHag.Subscriptions.Core.Events
{
    public class PublicationCreated : IEvent
    {
        public PublicationCreated(Guid publicationId, string title)
        {
            PublicationId = publicationId;
            Title = title;
        }

        public Guid PublicationId { get; set; }
        public string Title { get; set; }
    }
}
