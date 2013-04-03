using Ninject.Syntax;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.ReadStore
{
    public class DocumentStoreBootstrapper : IWantCustomInitialization
    {
        public void Init()
        {
            bool pass = true;
        }
    }
}
