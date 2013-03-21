using MagHag.Core.Messaging.EventSourcing;
using MagHag.Infrastructure.Data;
using MagHag.Infrastructure.Messaging.EventSourcing;
using Ninject.Modules;

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
