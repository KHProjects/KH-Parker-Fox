using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Ninject.Modules;
using Ninject.Web.Common;
using ParkerFox.Core.Entities.Repository;
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
            
            Bind<IUnitOfWork>().To<UnitOfWorkNhibernate>().InRequestScope();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IVisitorRepository>().To<VisitorRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ISubscriptionRepository>().To<SubscriptionRepository>();
            Bind<ICartItemRepository>().To<CartItemRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<ISessionFactory>().ToMethod(_ =>
                {
                    var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["main"].ConnectionString;

                    //var assembly = Assembly.GetExecutingAssembly();
                    //string currentPath = assembly.Location;
                    //string name = assembly.GetName().Name;
                    //string debugPath = String.Format("{0}\\bin\\Debug\\{0}.exe", name);
                    //string releasePath = String.Format("{0}\\bin\\Release\\{0}.exe", name);

                    //currentPath = currentPath.Replace(debugPath, "");
                    //currentPath = currentPath.Replace(releasePath, "");

                    //currentPath += "ParkerFox.Site\\App_data\\ParkerFox.sdf";

                    //connectionString = String.Format("Data Source={0}", currentPath);

                    return Fluently.Configure()
                    .Database(MsSqlCeConfiguration.Standard
                    .ConnectionString(connectionString)
                    .ShowSql()
                    .Driver<NHibernate.Driver.SqlServerCeDriver>()
                    .Dialect<NHibernate.Dialect.MsSqlCeDialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(x => x.SetProperty("connection.release_mode", "on_close"))
                    .BuildConfiguration().BuildSessionFactory();
                }).InRequestScope();
        }
    }
}
