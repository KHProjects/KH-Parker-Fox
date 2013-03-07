using MagHag.Site.Components;
using Ninject;

namespace MagHag.Site.App_Start
{
    public class IocConfig
    {
        public static void Setup()
        {
            var standardKernel = new StandardKernel();
            standardKernel.Load<Application.ApplicationModule>();
            standardKernel.Load<Infrastructure.InfrastructureModule>();

            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(standardKernel));
        }
    }
}