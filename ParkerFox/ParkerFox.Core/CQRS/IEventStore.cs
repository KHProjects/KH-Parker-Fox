using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public interface IEventStore
    {
        void Save(IEvent Event);
        IEvent NextEvent(Type aggregateRootType, Guid aggregateRootId, int version);
        IEnumerable<T> All<T>() where T : IEvent;
    }
}
