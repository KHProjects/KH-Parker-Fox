using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Messaging.Events
{
    public interface IEventStore
    {
        void StoreEvents(object streamId, IEnumerable<IEvent> events, long expectedInitialVersion);
        IEnumerable<IEvent> LoadEvents(object id, long version = 0);
        IEnumerable<IEvent> GetAllEventsEver();
    }
}
