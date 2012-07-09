using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public interface IHasAggregateRootId
    {
        Guid AggregateRootId { get; set; }
    }
}
