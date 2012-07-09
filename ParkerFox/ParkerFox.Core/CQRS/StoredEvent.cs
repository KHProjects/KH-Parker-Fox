using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public class StoredEvent
    {
        public IEvent Event { get; set; }
        public int Version { get; set; }
    }
}
