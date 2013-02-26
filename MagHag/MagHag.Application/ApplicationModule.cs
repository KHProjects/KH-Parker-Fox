using MagHag.Application.Messaging;
using MagHag.Core.Messaging;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Application
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IBus>().To<MessageBus>();
        }
    }
}
