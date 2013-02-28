using MagHag.Core.Entities;
using MagHag.Core.Messaging.Events;
using MagHag.Infrastructure.Data;
using Ninject.Modules;

namespace MagHag.Infrastructure
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventStore>().To<SqlEventStore>();
            Bind<IRepository>().To<Repository>();
        }
    }
}
