using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Publication
{
    public class Account
    {
        public virtual int AccountId { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
