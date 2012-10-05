using Ninject;
using Ninject.Selection.Heuristics;
using ParkerFox.Infrastructure;
using ParkerFox.Infrastructure.IoC;
using ParkerFox.Infrastructure.Web;
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

            //var kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false }, new Ninject.Extensions.Interception.DynamicProxyModule());
            
            kernel.Components.Add<IInjectionHeuristic, CustomPropertyInjectionHeuristic>();

            kernel.Load("ParkerFox.Infrastructure.dll");
            kernel.Load("ParkerFox.Application.dll");

            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);

            //below is how you would just supply ninject to controller injection
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
        }
    }
}