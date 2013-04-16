using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;

namespace MagHag.ReadStore
{
    /// <summary>
    /// http://www.strathweb.com/2012/05/using-ninject-with-the-latest-asp-net-web-api-source/
    /// </summary>
    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot _resolutionRoot;

        public NinjectScope(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = _resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return _resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = _resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return _resolutionRoot.Resolve(request).ToList();
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)_resolutionRoot;
            if (disposable != null) disposable.Dispose();
            _resolutionRoot = null;
        }
    }
}
