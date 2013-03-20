using MagHag.Application.Messaging;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.Extensions.MagHag.Application
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INotifyClient>().To<NotifyClient>();
        }
    }
}
