using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MagHag.Site.Components;
using NServiceBus;
using NServiceBus.Config;
using NServiceBus.ObjectBuilder;
using Ninject;
using Microsoft.AspNet.SignalR;
using MagHag.Subscriptions.Application.Messaging;


namespace MagHag.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            //TODO: create Bootstrap
            RouteTable.Routes.MapHubs(); //SignalR

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var kernel = CreateKernel();

            NServiceBus.Configure.With()
                .NinjectBuilder(kernel)
                .ForMVC()
                .Log4Net()
                .XmlSerializer()
                .MsmqTransport()
                    .MsmqSubscriptionStorage()
                    .IsTransactional(true)
                    .PurgeOnStartup(true)
                .DisableTimeoutManager()
                .UnicastBus()
                .CreateBus()
                .Start();

            GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);
            
            GlobalHost.DependencyResolver = new SignalRDependencyResolver(kernel); 
        }

        private IKernel CreateKernel()
        {
            var standardKernel = new StandardKernel();
            standardKernel.Bind<IUserConnectionRepository>().To<UserConnectionRepository>();
            return standardKernel;
        }
    }

    public static class ConfigureMvc3
    {
        public static Configure ForMVC(this Configure configure)
        {
            // Register our controller activator with NSB
            configure.Configurer.RegisterSingleton(typeof(IControllerActivator),
                new NServiceBusControllerActivator());

            // Find every controller class so that we can register it
            var controllers = Configure.TypesToScan
                .Where(t => typeof(IController).IsAssignableFrom(t));

            // Register each controller class with the NServiceBus container
            foreach (Type type in controllers)
                configure.Configurer.ConfigureComponent(type, ComponentCallModelEnum.Singlecall);

            // Set the MVC dependency resolver to use our resolver
            DependencyResolver.SetResolver(new NServiceBusResolverAdapter(configure.Builder));

            // Required by the fluent configuration semantics
            return configure;
        }
    }
}