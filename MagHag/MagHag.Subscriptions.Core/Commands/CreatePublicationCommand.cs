using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Core.Commands
{
    public class CreatePublicationCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
