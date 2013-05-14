using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Commands
{
    public class CreateSubscriptionCommand
    {
        public Guid PublicationId { get; set; }
        public string UserName { get; set; }
    }
}
