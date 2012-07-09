using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public interface IMessageHandler<TAggregate, TMessage> 
        where TAggregate : IAggregateRoot
        where TMessage : IMessage<TAggregate>
    {
        IEnumerable<IEvent> Handle(TMessage message, TAggregate aggregate);
    }
}
