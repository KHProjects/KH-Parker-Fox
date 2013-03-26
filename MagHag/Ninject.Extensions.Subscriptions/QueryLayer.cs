using MagHag.Subscriptions.Core.Queries;
using MagHag.Subscriptions.Infrastructure.Queries;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.Extensions.Subscriptions
{
    public class QueryLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IQueryPublications>().To<PublicationQueries>();
        }
    }
}
