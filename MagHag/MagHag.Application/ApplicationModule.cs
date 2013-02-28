using MagHag.Application.Messaging;
using MagHag.Application.Messaging.CommandHandlers;
using MagHag.Core.Messaging;
using MagHag.Core.Messaging.Commands;
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

            Bind<IHandleCommand<CreateAccount>>().To<CreateAccountHandler>();
        }
    }
}
