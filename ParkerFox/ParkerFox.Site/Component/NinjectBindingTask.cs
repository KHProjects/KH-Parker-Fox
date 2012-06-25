using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Repository;
using Ninject.Web.Common;
using System.Web.Http;

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

            //below is how you would just supply ninject to controller injection
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));

            //TODO: TWO! really
            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel); 
        }
    }
}