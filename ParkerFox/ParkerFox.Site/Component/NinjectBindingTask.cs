using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Ninject;
using ParkerFox.Application.Messaging;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Repository;
using Ninject.Web.Common;
using System.Web.Http;
using ParkerFox.Infrastructure.Messaging;
using ParkerFox.Core.Messaging;

namespace ParkerFox.Site.Component
{
    public class NinjectBindingTask : IBootStrapTask
    {
        public int Priority
        {
            get { return 0; }
        }

        public void Execute()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IVisitorRepository>().To<VisitorRepository>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ISubscriptionRepository>().To<SubscriptionRepository>();

            kernel.Bind<IRequestState>().To<AspRequestState>();
            kernel.Bind<IActiveSessionManager>().To<ActiveSessionManager>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IBus>().To<ApplicationBus>();

            kernel.Load(Assembly.Load("ParkerFox.Application"));

            //below is how you would just supply ninject to controller injection
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));

            //TODO: TWO! really
            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);

        }
    }
}