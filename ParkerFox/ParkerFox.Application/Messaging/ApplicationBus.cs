using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Syntax;
using ParkerFox.Core.Messaging;
using ParkerFox.Infrastructure.Messaging;
using ParkerFox.Infrastructure.Messaging.Commands;
using ParkerFox.Infrastructure.Messaging.Events;

namespace ParkerFox.Application.Messaging
{
    public class ApplicationBus : IBus
    {
        private readonly IResolutionRoot _resolutionRoot;

        public ApplicationBus(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public void Send<TCommand>(TCommand command)
        {
            var type = typeof(IHandleCommand<>).MakeGenericType(new[] { typeof(TCommand) });
            var handler = _resolutionRoot.TryGet(type) as IHandleCommand<TCommand>;
            if (handler == null)
                throw new Exception(String.Format("Handler not found for command {0}", command.GetType()));
            handler.Handle(command);
        }

        public void Publish<TEvent>(TEvent @event)
        {
            var type = typeof(IRespondToEvent<>).MakeGenericType(new[] { typeof(TEvent) });

            var responders = _resolutionRoot.GetAll(type);
            foreach (var handler in responders.Select(responder => responder as IRespondToEvent<TEvent>))
            {
                handler.Raise(@event);
            }
        }
    }
}
