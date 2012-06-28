using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Magazine
{
    public class Publication
    {
        public virtual int PublicationId { get; set; }
        public virtual string Name { get; set; }
    }
}
