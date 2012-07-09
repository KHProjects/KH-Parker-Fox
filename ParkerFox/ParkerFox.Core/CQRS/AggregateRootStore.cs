using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public class AggregateRootStore : IAggregateRootStore
    {
        public IAggregateRoot GetAggregateRoot(Type aggregateRootType, Guid aggregateRootId)
        {
            throw new NotImplementedException();
        }

        public int GetAggregateRootVersion(Type aggregateRootType, Guid aggregateRootId)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(IAggregateRoot aggregateRoot, int version)
        {
            throw new NotImplementedException();
        }
    }
}
