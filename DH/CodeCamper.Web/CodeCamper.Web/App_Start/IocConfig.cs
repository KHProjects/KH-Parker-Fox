using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Helpers;
using Ninject;

namespace CodeCamper.Web.App_Start
{
  public class IocConfig
  {
    public static void RegisterIoc(HttpConfiguration config)
    {
      var kernel = new StandardKernel(); // Ninject IoC

      kernel.Bind<ICodeCamperUow>().To<CodeCamperUow>();
      kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
      kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();

      // Tell WebApi how to use our Ninject IoC
      config.DependencyResolver = new NinjectDependencyResolver(kernel);
    }


  }
}