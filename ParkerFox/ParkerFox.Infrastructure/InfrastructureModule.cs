using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Ninject.Modules;
using Ninject.Web.Common;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Core.Entities.Repository.Publication;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Repository;
using ParkerFox.Infrastructure.Repository.Ecommerce;
using ParkerFox.Infrastructure.Repository.Publication;
using System.Configuration;
using System.Diagnostics;
using System.Web.Mvc;
using ParkerFox.Infrastructure.Web;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Request;

namespace ParkerFox.Infrastructure
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestState>().To<AspRequestState>();

            if(string.Equals(ConfigurationManager.AppSettings["ORM"], "NH"))
                BindNHibernate();
            else
                BindEntityFramework();

            Bind<IUnitOfWork>().To<UnitOfWorkNhibernate>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IVisitorRepository>().To<VisitorRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ISubscriptionRepository>().To<SubscriptionRepository>();
            Bind<ICartItemRepository>().To<CartItemRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            
            Bind<ISessionFactory>().ToMethod(_ =>
                {
                    var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["main"].ConnectionString;

                    return Fluently.Configure()
                    //.ExposeConfiguration(x => x.SetInterceptor(new QueryInterceptor()))
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

        private void BindNHibernate()
        {
            
        }

        private void BindEntityFramework()
        {
            
        }
    }

    public class QueryInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Debug.WriteLine(sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
}