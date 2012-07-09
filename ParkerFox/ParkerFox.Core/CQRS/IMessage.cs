using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public interface IMessage : IHasAggregateRootId
    {
        Type AggregateRootType { get; set; }
    }

    public interface IMessage<TAggregate> : IMessage where TAggregate : IAggregateRoot
    {
    }
}
