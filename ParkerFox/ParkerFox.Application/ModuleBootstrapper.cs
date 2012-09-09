using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.ApplicationServices;

namespace ParkerFox.Application
{
    public class ModuleBootstrapper : NinjectModule
    {
        public override void Load()
        {
            Bind<ICartServices>().To<CartServices>();
        }
    }
}
