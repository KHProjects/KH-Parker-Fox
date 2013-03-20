using MagHag.Core.Messaging.EventSourcing;
using MagHag.Infrastructure.Data;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.Extensions.MagHag.Infrastructure
{
    public class EventSourcing : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventStore>().To<SqlEventStore>();
        }
    }
}
