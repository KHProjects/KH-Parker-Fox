﻿

using System.Collections.Concurrent;
using System.Linq;
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

            AggregateUpdater.Update(this, @event);
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

        private static class AggregateUpdater
        {
            private static readonly ConcurrentDictionary<Tuple<Type, Type>, Action<Aggregate, object>> cache = new ConcurrentDictionary<Tuple<Type, Type>, Action<Aggregate, object>>();

            public static void Update(Aggregate instance, object @event)
            {
                var tuple = new Tuple<Type, Type>(instance.GetType(), @event.GetType());
                var action = cache.GetOrAdd(tuple, ActionFactory);
                action(instance, @event);
            }

            private static Action<Aggregate, object> ActionFactory(Tuple<Type, Type> key)
            {
                var eventType = key.Item2;
                var aggregateType = key.Item1;

                const string methodName = "UpdateFrom";
                var method = aggregateType.GetMethods(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    .SingleOrDefault(x => x.Name == methodName && x.GetParameters().Single().ParameterType.IsAssignableFrom(eventType));

                if (method == null)
                    return (x, y) => { };

                return (instance, @event) => method.Invoke(instance, new[] { @event });
            }
        }
    }
}
