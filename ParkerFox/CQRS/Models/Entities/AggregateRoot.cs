using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models.Entities
{
    /// <summary>
    /// Event dispatch options: http://thinkbeforecoding.com/post/2009/11/03/Event-Sourcing-and-CQRS-Dispatch-options
    /// </summary>
    public class AggregateRoot : IAggregateRoot
    {
        public AggregateRoot(Guid id)
        {
            Id = id;
            Version = 0;
        }

        public AggregateRoot(IEventInputStream events) : this(events.AggregateId)
        {
            Version = events.Version;
            foreach (var @event in events.Events)
            {
                ExecuteHandler(@event);
            }
        }

        private List<IEvent>  _uncommittedEvents = new List<IEvent>();
        //private static Dictionary<Type, Dictionary<Type, Delegate>> _applyDelegates = new Dictionary<Type, Dictionary<Type, Delegate>>();
        private static Dictionary<Type, Action<object>> _applyDelegates =new Dictionary<Type, Action<object>>();

        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public IEnumerable<IEvent> UncommitedEvents
        {
            get { return _uncommittedEvents; }
        }

        protected virtual void ApplyEvent<T>(T @event) where T : IEvent
        {
            ExecuteHandler(@event);
            _uncommittedEvents.Add(@event);
        }

        protected void Register<T>(Action<T> handler) where T:IEvent
        {
            _applyDelegates.Add(typeof (T), e => handler((T) e));
        }

        private void ExecuteHandler<T>(T @event) where T : IEvent
        {
            _applyDelegates[@event.GetType()](@event);
        }
    }
}