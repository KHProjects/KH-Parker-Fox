using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CQRS.Models
{
    public interface IAggregateRoot 
    {
        Guid Id { get;}
        IEnumerable<IEvent> UncommitedEvents { get; }
        int Version { get; }
    }
}
