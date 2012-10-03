using Ninject;
using ParkerFox.Infrastructure.Web;
using ParkerFox.Infrastructure.Web.MessageHandlers;
using ParkerFox.WebApi.Ecommerce;
using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ParkerFox.WebApi.Host
{
    class Program
    {        
        static void Main(string[] args)
        {
            var configuration = GetSelfHostConfiguration();

            //--Bug with controller locating http://forums.asp.net/post/4848156.aspx
            Type productController = typeof(ProductController);
 
            using (var server = new HttpSelfHostServer(configuration))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Web Api Server Ready....");
                Console.ReadLine();
            }
        }

        private static HttpSelfHostConfiguration GetSelfHostConfiguration()
        {
            var configuration = new HttpSelfHostConfiguration("http://localhost:8181");

            configuration.Routes.MapHttpRoute("Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            configuration.MessageHandlers.Add(new HttpMethodOverrideHandler());

            SetupNinject(configuration);

            return configuration;
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
