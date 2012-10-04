using Ninject.Modules;
using ParkerFox.Application.Messaging;
using ParkerFox.Application.Services.Publication;
using ParkerFox.Core.ApplicationServices;
using ParkerFox.Core.ApplicationServices.Publication;
using ParkerFox.Core.Messaging;

namespace ParkerFox.Application
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBus>().To<ApplicationBus>();
            Bind<ICartServices>().To<CartServices>();
            Bind<ISubscriptionServices>().To<SubscriptionServices>();
        }
    }
}
