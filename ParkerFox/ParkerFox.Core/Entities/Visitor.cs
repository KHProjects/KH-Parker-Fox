using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities
{
    public class Visitor
    {
        public virtual int VisitorId { get; set; }
        public virtual int IpAddress { get; set; }
        public virtual DateTime LastVisit { get; set; }
    }
}
