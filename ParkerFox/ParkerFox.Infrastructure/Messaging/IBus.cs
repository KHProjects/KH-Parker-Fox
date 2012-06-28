using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Messaging
{
    public interface IBus
    {
        void Send<TCommand>(TCommand command);
        void Publish<TEvent>(TEvent @event);
    }
}
