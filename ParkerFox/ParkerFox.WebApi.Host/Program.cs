using Ninject;
using ParkerFox.Application.Messaging;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Core.Messaging;
using ParkerFox.Infrastructure.Data;
using ParkerFox.Infrastructure.Repository;
using ParkerFox.Infrastructure.Web;
using ParkerFox.WebApi.Ecommerce;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ParkerFox.WebApi.Host
{
    class Program
    {        
        static void Main(string[] args)
        {
            var configuration = new HttpSelfHostConfiguration("http://localhost:8181");

            configuration.Routes.MapHttpRoute("Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            SetupNinject(configuration);

            DataConfig.EnsureStartup();

            //--Bug with controller locating http://forums.asp.net/post/4848156.aspx

            Type productController = typeof(ProductController);
 
            using (HttpSelfHostServer server = new HttpSelfHostServer(configuration))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Web Api Server Ready....");
                Console.ReadLine();
            }
        }

        private static void SetupNinject(HttpSelfHostConfiguration configuration)
        {
            IKernel kernel = new StandardKernel();

            kernel.Load("ParkerFox.Infrastructure.dll");
            kernel.Load("ParkerFox.Application.dll");

            //below is how you would just supply ninject to controller injection
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));

            configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);
        }
    }
}
