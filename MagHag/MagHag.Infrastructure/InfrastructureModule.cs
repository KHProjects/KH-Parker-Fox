using MagHag.Core.Messaging;
using MagHag.Core.Messaging.Events;
using MagHag.Infrastructure.Messaging.EventSourcing;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Infrastructure
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventStore>().To<SqlEventStore>();
        }
    }
}
