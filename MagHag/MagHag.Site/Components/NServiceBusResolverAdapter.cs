using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NServiceBus.ObjectBuilder;

namespace MagHag.Site.Components
{
    public class NServiceBusResolverAdapter : IDependencyResolver
    {
        private IBuilder builder;

        public NServiceBusResolverAdapter(IBuilder builder)
        {
            this.builder = builder;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return builder.Build(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return builder.BuildAll(serviceType);
        }
    }
}