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
        public void Send<T>(T command)
        {
            throw new NotImplementedException();
        }

        public void Publish<T>(T @event)
        {
            throw new NotImplementedException();
        }
    }
}
