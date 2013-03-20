
using MagHag.Core.Messaging.EventSourcing;
using MagHag.Core.Messaging.Events;
using System;
using System.Collections.Generic;

namespace MagHag.Core.Entities
{
    public abstract class Aggregate
    {
        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();

        public Guid Id { get; protected set; }
        public long Version { get; private set; }

        public void Apply<T>(T @event) where T:IEvent
        {
            _uncommittedEvents.Add(@event);
            Version++;

            dynamic _this = this;
            _this.ApplyEvent(@event);
        }

        public void LoadFromHistory(IEnumerable<IEvent> events)
        {
            dynamic _this = this;

            foreach (var @event in events)
            {
                _this.ApplyEvent(@event);
                Version++;
            }
        }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return _uncommittedEvents;
        }

        protected dynamic DynThis
        {
            get
            {
                return this as dynamic;
            }
        }

        public void ClearEvents()
        {
            _uncommittedEvents.Clear();
        }
    }
}
