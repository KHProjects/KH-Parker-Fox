using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Application.Messaging;
using ParkerFox.Core.ApplicationServices;
using ParkerFox.Core.Messaging;

namespace ParkerFox.Application
{
    public class ModuleBootstrapper : NinjectModule
    {
        public override void Load()
        {
            Bind<IBus>().To<ApplicationBus>();
            Bind<ICartServices>().To<CartServices>();
        }
    }
}
