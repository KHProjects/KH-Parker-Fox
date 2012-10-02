using System;

namespace ParkerFox.Infrastructure.Messaging.Commands
{
    public interface IHandleCommand<TCommand>
    {
        void Handle(TCommand command);
    }
    public interface IHandleCommand<TCommand, TResponse>
    {
        TResponse Handle(TCommand command);
    }
}
