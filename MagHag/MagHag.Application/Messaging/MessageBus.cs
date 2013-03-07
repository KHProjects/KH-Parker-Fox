using MagHag.Core.Messaging;
using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagHag.Application.Messaging
{
    public sealed class MessageBus : IApplicationBus
    {
        private readonly IResolutionRoot _resolutionRoot;
        readonly Dictionary<Type, List<Action<object>>> _handlers = new Dictionary<Type, List<Action<object>>>();

        public MessageBus(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public void Publish<T>(T @event)
        {
            var type = typeof(IObserveEvent<>).MakeGenericType(new[] { typeof(T) });

            _resolutionRoot.GetAll(type)
                .Select(_ => _ as IObserveEvent<T>)
                .ToList()
                .ForEach(_=>_.Notify(@event));
         }

        public void Send<T>(T command)
        {
            var type = typeof(IHandleCommand<>).MakeGenericType(new[] { typeof(T) });
            var handler = _resolutionRoot.TryGet(type) as IHandleCommand<T>;
            if (handler == null)
                throw new Exception(String.Format("Handler not found for command {0}", command.GetType()));
            handler.Handle(command);
        }

    }
}
