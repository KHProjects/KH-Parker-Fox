using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagHag.Core.Entities;
using MagHag.Infrastructure.Data;
using Ninject.Modules;

namespace Ninject.Extensions.MagHag.Infrastructure
{
    public class DataAccess : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository>();
        }
    }
}
