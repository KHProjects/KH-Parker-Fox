using Ninject;
using ParkerFox.Infrastructure;
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

            kernel.Load("ParkerFox.Infrastructure.dll");
            kernel.Load("ParkerFox.Application.dll");

            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);

            //below is how you would just supply ninject to controller injection
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
        }
    }
}