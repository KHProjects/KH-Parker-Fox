using MagHag.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Application.Messaging
{
    public sealed class MessageBus : IBus
    {
        readonly Dictionary<Type, List<Action<object>>> _handlers = new Dictionary<Type, List<Action<object>>>();

        public void Publish(IEnumerable<object> events)
        {
            foreach (var @event in events)
                PublishEvent(@event);
        }

        private void Publish<T>(T @event)
        {
            var type = @event.GetType();
            var keys = _handlers.Keys.Where(x => x.IsAssignableFrom(type));

            foreach (var key in keys)
                foreach (var handler in _handlers[key])
                    handler(@event);
        }

        public void RegisterHandler<T>(Action<T> handler)
        {
            List<Action<object>> handlers;

            if (!_handlers.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<object>>();
                _handlers.Add(typeof(T), handlers);
            }

            handlers.Add(x => handler((T)x));
        }

        public void Send<T>(T command)
        {
            List<Action<object>> handlers;

            if (!_handlers.TryGetValue(command.GetType(), out handlers))
                throw new InvalidOperationException(string.Format("No handler registered for command type {0}", command.GetType()));
            if (handlers.Count != 1) throw new InvalidOperationException("Cannot send to more than one handler");

            handlers[0](command);
        }

    }
}
