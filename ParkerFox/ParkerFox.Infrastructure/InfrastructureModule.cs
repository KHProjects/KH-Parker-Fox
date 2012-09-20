using Ninject.Modules;
using Ninject.Web.Common;
using ParkerFox.Core.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Repository;
using ParkerFox.Infrastructure.Repository.Ecommerce;

namespace ParkerFox.Infrastructure
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestState>().To<AspRequestState>();
            Bind<IActiveSessionManager>().To<ActiveSessionManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IVisitorRepository>().To<VisitorRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ISubscriptionRepository>().To<SubscriptionRepository>();
        }
    }
}
