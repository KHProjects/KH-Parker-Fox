using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Framework
{
    public class DomainRepository : IRepository
    {
        private IEventStore _eventStore;

        public DomainRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public T GetById<T>(object id) where T : Aggregate
        {
            var events = _eventStore.LoadEvents(id);
            var aggregate = (T) Activator.CreateInstance(typeof (T), true);
            aggregate.LoadFromHistory(events);

            return aggregate;
        }

        public void Save(Aggregate aggregate)
        {
            var newEvents = aggregate.GetUncommittedChanges().ToList();
            var currentVersion = aggregate.Version;
            var initialVersion = currentVersion - newEvents.Count;

            _eventStore.StoreEvents(aggregate.Id, newEvents, initialVersion);
            aggregate.ClearUncommittedEvents();
        }
    }
}