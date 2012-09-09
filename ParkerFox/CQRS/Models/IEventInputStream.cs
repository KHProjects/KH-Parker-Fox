using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IEventInputStream
    {
        IEnumerable<IEvent> Events { get; }
        int Version { get; }
        Guid AggregateId { get;} 
    }
}