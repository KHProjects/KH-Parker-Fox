using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public interface IAggregateRootStore
    {
        IAggregateRoot GetAggregateRoot(Type aggregateRootType, Guid aggregateRootId);
        int GetAggregateRootVersion(Type aggregateRootType, Guid aggregateRootId);
        void SaveOrUpdate(IAggregateRoot aggregateRoot, int version);
    }
}
