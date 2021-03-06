﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace ParkerFox.Infrastructure.Web
{
    /// <summary>
    /// 
    /// </summary>
    /// <links>
    /// http://www.strathweb.com/2012/05/using-ninject-with-the-latest-asp-net-web-api-source/
    /// </links>
    public class NinjectHttpDependencyResolver : NinjectScope, IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectHttpDependencyResolver(IKernel kernel) 
            : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}