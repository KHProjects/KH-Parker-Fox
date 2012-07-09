using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    class StoredAggregateRoot
    {
        public IAggregateRoot Instance { get; set; }
        public int Version { get; set; }
        public Type Type { get { return Instance.GetType(); } }
    }
}
