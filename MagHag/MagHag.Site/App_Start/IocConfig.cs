using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MagHag.Site.App_Start
{
    public class IocConfig
    {
        public static void Setup()
        {
            var standardKernel = new StandardKernel();
            standardKernel.Load(Assembly.Load("MagHag.Application"));
        }
    }
}