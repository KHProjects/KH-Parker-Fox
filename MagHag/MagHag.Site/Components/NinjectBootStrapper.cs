using System.Web.Http;
using MagHag.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Selection.Heuristics;

namespace MagHag.Site.Components
{
    public class NinjectBootStrapper : IBootStrapTask
    {
        public int Priority
        {
            get { return 0; }
        }

        public void Execute()
        {
            IKernel kernel = new StandardKernel();

            //var kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false }, new Ninject.Extensions.Interception.DynamicProxyModule());

            //kernel.Components.Add<IInjectionHeuristic, CustomPropertyInjectionHeuristic>();

            kernel.Load("MagHag.Infrastructure.dll");
            kernel.Load("MagHag.Application.dll");

            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            //GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);

            //below is how you would just supply ninject to controller injection
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
        }
    }
}