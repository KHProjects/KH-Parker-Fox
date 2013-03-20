using System;
using System.Collections.Generic;

namespace MagHag.Core.Messaging.EventSourcing
{
    public interface IEventStore
    {
        void StoreEvents(Guid streamId, IEnumerable<IEvent> events, long expectedInitialVersion);
        IEnumerable<IEvent> LoadEvents(Guid id, long version = 0);
        IEnumerable<IEvent> GetAllEventsEver();
    }
}
