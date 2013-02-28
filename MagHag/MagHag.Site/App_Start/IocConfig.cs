using MagHag.Site.Components;
using Ninject;

namespace MagHag.Site.App_Start
{
    public class IocConfig
    {
        public static void Setup()
        {
            var standardKernel = new StandardKernel();

            standardKernel.Load("MagHag.Infrastructure.dll");
            standardKernel.Load("MagHag.Application.dll");

            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(standardKernel));
        }
    }
}