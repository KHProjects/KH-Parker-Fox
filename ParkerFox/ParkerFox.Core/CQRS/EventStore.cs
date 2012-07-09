using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public class EventStore : IEventStore
    {
        private List<StoredEvent> _store = new List<StoredEvent>();

        public void Save(IEvent Event)
        {
            var lastEvent = _store.LastOrDefault(x => x.Event.AggregateRootId == Event.AggregateRootId);
            var version = lastEvent == null ? 0 : lastEvent.Version + 1;
            _store.Add(new StoredEvent
                {
                    Event =  Event,
                    Version =  version
                });
        }

        public IEvent NextEvent(Type aggregateRootType, Guid aggregateRootId, int version)
        {
            return _store
                .Where(x =>
                       x.Event.AggregateRootType == aggregateRootType && 
                       x.Event.AggregateRootId == aggregateRootId &&
                       x.Version == version)
                .Select(x => x.Event)
                .FirstOrDefault();
        }

        public IEnumerable<T> All<T>() where T : IEvent
        {
            return _store.Select(x => x.Event).OfType<T>();
        }
    }
}
