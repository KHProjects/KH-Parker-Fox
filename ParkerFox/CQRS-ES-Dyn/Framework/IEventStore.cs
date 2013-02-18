using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Framework
{
    public interface IEventStore
    {
        void StoreEvents(object streamId, IEnumerable<object> events, long expectedInitialVersion);
        IEnumerable<object> LoadEvents(object id, long version = 0);
        IEnumerable<object> GetAllEventsEver();
    }
}