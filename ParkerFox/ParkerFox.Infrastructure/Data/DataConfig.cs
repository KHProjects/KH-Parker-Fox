using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using ParkerFox.Infrastructure.Data.Mapping;

namespace ParkerFox.Infrastructure.Data
{
    public class DataConfig
    {
        private static ISessionFactory _sessionFactory;
        private static bool _startupComplete = false;
        private static readonly object _locker = new object();

        public static ISession GetSession()
        {
            var session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            return session;            
        }

        public static void EnsureStartup()
        {
            if (!_startupComplete)
            {
                lock (_locker)
                {
                    if (!_startupComplete)
                    {
                        DataConfig.PerformStartup();
                        _startupComplete = true;
                    }
                }
            }
        }

        private static void PerformStartup()
        {
            InitializeSessionFactory();
        }

        private static void InitializeSessionFactory()
        {
            var configuration = BuildConfiguration();
            _sessionFactory = configuration.BuildSessionFactory();
        }

        private static Configuration BuildConfiguration()
        {
            //return Fluently.Configure(new Configuration().Configure())
            //    .Mappings(cfg => cfg.FluentMappings.AddFromAssembly(typeof(VisitorMapping).Assembly))
            //    .BuildConfiguration();
            return Fluently.Configure()
            .Database(MsSqlCeConfiguration.Standard
            .ConnectionString(@"Data Source=|DataDirectory|\ParkerFox.sdf")
            .Driver<NHibernate.Driver.SqlServerCeDriver>()
            .Dialect<NHibernate.Dialect.MsSqlCeDialect>())
            .Mappings(m => m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()))
                //.ExposeConfiguration(BuildSchema)
            .ExposeConfiguration(x => x.SetProperty("connection.release_mode", "on_close"))            
            .BuildConfiguration();
        }           
    }
}
