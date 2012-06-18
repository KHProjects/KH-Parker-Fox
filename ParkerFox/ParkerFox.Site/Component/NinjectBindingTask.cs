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

            kernel.Bind<IRequestState>().To<AspRequestState>();
            kernel.Bind<IActiveSessionManager>().To<ActiveSessionManager>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            var resolver = new NinjectDependencyResolver(kernel);

            System.Web.Mvc.DependencyResolver.SetResolver(resolver);
        }
    }
}