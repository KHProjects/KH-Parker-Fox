using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IEventStore
    {
        void Persist(IAggregateRoot aggregateRoot);

        IEnumerable<IEventInputStream> Load(Guid aggregateId);
    }
}