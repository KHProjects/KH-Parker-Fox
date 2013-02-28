using MagHag.Application;
using MagHag.Core.Entities;
using MagHag.Core.Messaging.Events;
using Ninject;
using Ninject.Syntax;
using System;
using System.Linq;

namespace MagHag.Infrastructure.Data
{
    public sealed class Repository : IRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IResolutionRoot _resolutionRoot;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public T GetById<T>(Guid id) where T : Aggregate
        {
            var events = _eventStore.LoadEvents(id);
            var aggregate = (T)_resolutionRoot.Get(typeof (T));
            aggregate.LoadFromHistory(events);
            return aggregate;
        }

        public void Save(Aggregate aggregate)
        {
            var events = aggregate.GetUncommittedChanges().ToList();
            var currentVersion = aggregate.Version;
            var initialVersion = currentVersion - events.Count;

            _eventStore.StoreEvents(aggregate.Id, events, initialVersion);
            aggregate.ClearEvents();
        }
    }
}
