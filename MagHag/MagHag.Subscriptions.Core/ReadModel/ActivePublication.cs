using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.ReadModel
{
    public class ActivePublication
    {
        public Guid PublicationId { get; set; }                
        public string Title { get; set; }
    }
}
