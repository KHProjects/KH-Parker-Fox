
using MagHag.Core.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Entities
{
    public class User : Aggregate
    {
        public User()
        {
            Apply(new UserCreated());
        }

        public void ApplyEvent(UserCreated userCreated)
        {
            bool pass = true;
        }

        
    }
}
